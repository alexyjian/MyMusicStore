using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using Music.ViewModels;
using MusicStoreEntity.UserAndRole;

namespace Music.Controllers
{
    public class OrderController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }

            //2.查询出当前用户Person 查询该用户的购物项
            var persons = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var selectItemList = new List<SelectListItem>();
            foreach (var it in _context.PersonAddresss.Where(x=>x.persons.ID==persons.ID))
            {
                selectItemList.Add(new SelectListItem() { Value = it.ID.ToString(), Text = "收件人：" + it.AddresPerson + "，收货地址：" + it.Address + "，手机号：" + it.MobileNumber, Selected = true });
            }
            ViewBag.Person = selectItemList;

            var carts = _context.Carts.Where(x => x.Person.ID == persons.ID).ToList();
            //计算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum(); //Linq表达式
            //3.创建新Order对象
            var  order=new Order()
            {
                AddresPerson = persons.Name,
                Mobilnumber = persons.MobileNumber,
                Person = _context.Persons.Find(persons.ID),
                TotalPrice = totalPrice??0.00M
            };
            //4.把购物项导入订单明
            order.OrderDetails=new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail=new OrderDetail()
                {
                    AlbumID = item.AlbumID,
                    Album = _context.Albums.Find(item.Album.ID),
                    Count = item.Count,
                    Price = item.Album.Price
                };
                order.OrderDetails.Add(detail);
            }
            //将订单和明细在视图呈现，验证用户收件人、地址、电话，供用户选择确认要购买专辑
            //当前订单未持久化，用户会话保存方便用户进行编辑
            Session["Order"] = order;
            return View(order);
        }
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空，则重新刷新页面
            if (Session["Order"] == null)
            {
                return RedirectToAction("buy");
            }
            //读取会话中的Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x=>x.ID==id);
            //从订单明细列表中移除明细纪录
            order.OrderDetails.Remove(deleteDetail);
            
            //根据新的order对象,重新生成Html脚本，返回json数据，局部刷新视图


            //订单总价
            var totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum(); //Linq表达式
            var htmlString = "";
            //更新保存会话
            Session["Order"] = order;
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='" +Url.Action("Detail","Store",new {id = item.Album.ID }) + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + " </td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeDetail('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\">移除购物车</i></a></td>";
            }
            htmlString += "<tr><td></td><td></td ><td>总价</td><td>" + totalPrice.ToString("C") + "</ td ></ tr >";

            return Json(htmlString);
        }
        /// <summary>
        /// 处理用户提交订单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(string id)
        {
           
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }
            //2.读出当前用户Person
            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            if (id != null)
            {
                Session["address"]= _context.PersonAddresss.Find(Guid.Parse(id));
                var addres = Session["address"] as PersonAddress;
                var order = new Order();
                

                order.Person = _context.Persons.Find(person.ID);

                order.Addders = addres.Address;
                order.AddresPerson = addres.AddresPerson;
                order.Mobilnumber = addres.MobileNumber;
                //3.从会话中读出订单明细列表

                order.OrderDetails = new List<OrderDetail>();
                var details = (Session["Order"] as Order).OrderDetails;
                foreach (var item in details)
                {

                    item.Album = _context.Albums.Find(item.Album.ID);
                    order.OrderDetails.Add(item);
                }
                order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum(); //Linq表达式;

                //4.如果表单验证通过，则保存order到数据库()，跳转到Pay/AliPay

                if (ModelState.IsValid)
                {
                    //加锁
                    LockedHelp.ThreadLocked(order.ID);
                    try
                    {
                        _context.Orders.Add(order);

                        //清空购物车
                        var carts = _context.Carts.Where(x => x.Person.ID == order.Person.ID);
                        foreach (var item in order.OrderDetails)
                        {

                            _context.Carts.Remove(carts.FirstOrDefault(x => x.Album.ID == item.Album.ID));
                        }

                        _context.SaveChanges();
                    }
                    catch
                    {
                    }
                    finally
                    {
                        LockedHelp.ThreadUnlocked(order.ID);
                    }
                    //跳转到支付页Pay/AliPay
                    ViewBag.OrderID = order.ID;
                    var url = "<script>location.href='" + Url.Action("Alipay", "Pay", new { id = Guid.Parse(@ViewBag.OrderID.ToString())}) + "'</script>";
                    return Json(url);
                    // return RedirectToAction("Alipay", "Pay", new { id = order.ID });
                }
                //5.如果验证不通过，返回视图
                return Content("<script>alert('购买失败!');location.href='" + Url.Action("index", "home") + "'</script>");
            }
           
            var selectItemList = new List<SelectListItem>();
            foreach (var it in _context.PersonAddresss.Where(x => x.persons.ID == person.ID))
            {
                selectItemList.Add(new SelectListItem() { Value = it.ID.ToString(), Text = "收件人：" + it.AddresPerson + "，收货地址：" + it.Address + "，手机号：" + it.MobileNumber, Selected = true });
            }
            ViewBag.Person = selectItemList;
            var orders= Session["Order"];
            return View(orders);
        }
        /// <summary>
        /// 浏览用户订单
        /// </summary>
        /// <returns></returns>
        // GET: Order
        public ActionResult Index()
        {
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }
            //2.读出当前用户Person

            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;

            //3.读出订单明细

            var orders = _context.Orders.Where(x => x.Person.ID == person.ID ).ToList();
            
            return View(orders);
        }
    }
}