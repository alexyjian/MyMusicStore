using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
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

            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });
             
            //查询出当前登录用户 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车总价
            decimal? totalRirce = (from item in carts select item.Count * item.Album.Price).Sum();//linq表达式一句完成


            //创建新Oeder对象
            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
            TotalPrice = totalRirce ?? 0.00M,
            };

            //把购物项导入订单明细
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail = new OrderDetail()
                {
                    AlbumID = item.AlbumID,
                    Album = _context.Albums.Find(item.Album.ID),
                    Count = item.Count,
                    Price = item.Album.Price
                };
                order.OrderDetails.Add(detail);
            }

            //将订单和明细在视图呈现，验证用户收件人 地址 电话 供用户选择确认要购买专辑

            //
            Session["Order"]= order;
            return View(order);
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空，则重新刷新页面
            if (Session["Order"] == null)
                return RedirectToAction("buy");

            //读取会话中的Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表中移除明细记录
            order.OrderDetails.Remove(deleteDetail);

            //根据新的order对象重新生成Html,返回json数据，局部刷新视图
            var totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();//linq表达式一句完成
            //编辑到用户会话
            Session["Order"] = order;
            var htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../Store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"RemoveDetail('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>移出购物车</a></td><tr>";
            }

            htmlString += "<tr><td ></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td ></tr>";

            return Json(htmlString);
        }

        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            //1 判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });
            //2 读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            oder.Person = _context.Persons.Find(person.ID);
            
            //3 从会话中读出订单明细列表
            oder.OrderDetails = new List<OrderDetail>();

            var details = (Session["Order"] as Order).OrderDetails;
            foreach (var item in details)
            {
                item.Album = _context.Albums.Find(item.Album.ID);
                oder.OrderDetails.Add(item);

            }

            oder.TotalPrice = (from item in oder.OrderDetails select item.Count * item.Album.Price).Sum();//linq表达式一句完成

            //4 如果表单验证通过，则保存order到数据库（锁定进程），跳转到支付页
            if (ModelState.IsValid)
            {
                //加锁
                LockedHelp.Threadlocked(oder.id);
                try
                {
                    _context.Orders.Add(oder);
                    _context.SaveChanges();

                    //清空购物车
                    var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
                    foreach (var cart in carts)
                    {
                        _context.Carts.Remove(cart);
                    }
                    _context.SaveChanges();

                    //把订单中的收件人信息保存带person中
                    var p = _context.Persons.Find(person.ID);
                    p.MobileNumber = oder.MobilNumber;
                    p.Address = oder.Address;
                    p.Name = oder.AddressPerson;
                    p.FirstName = p.Name.Substring(0, 1);
                    p.LastName = p.Name.Substring(1, p.Name.Length - 1);
                    _context.SaveChanges();
                }
                catch
                {
                }
                finally
                {
                    LockedHelp.ThreadUnLocked(oder.id);
                }
                //跳转到支付页Pay/AliPay 
                return RedirectToAction("Alipay", "Pay", new { id = oder.id });
                

            }
            //5 如果验证不通过，返回视图
            else {
                
                
                ViewBag.ReturnUrl = Url.Action("Buy", "Order");
            }
                return View();
        }

        /// <summary>
        /// 浏览用户订单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询出该用户的购物车项
            var orders = _context.Orders.Where(x => x.Person.ID == x.Person.ID).ToList();

            return View(orders);
           
        }

    }
}