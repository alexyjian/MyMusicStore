using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        // GET: Order
        public ActionResult Buy()
        {
            //1.确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();

            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            //3.创建新Order对象，

            var order = new Order()
            {
                AddressPerson = person.Name,
                MobiNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
                TotalPrice = totalPrice ?? 0.00M,
            };
            order.OrdelDetails = new List<OrdelDetail>();
            foreach (var i in carts)
            {
                //4.把购物项导入订单明细
                var detail = new OrdelDetail()
                {
                    AlbumID = i.AlbumID,
                    Album = _context.Albums.Find(i.Album.ID),
                    Count = i.Count,
                    Price = i.Album.Price
                };
                order.OrdelDetails.Add(detail);
            }

            //将订单和明细在视图呈现 验证用户收件人、地址、电话 供用户选择确认要购买的专辑

            //当前订单未持久化，用会话保存方便用户编辑
            Session["Order"] = order;

            //收货人下拉框
            var addperson = person.PerAddress.ToList();

            var list = new List<SelectListItem>();

            foreach (var i in addperson)
            {
                list.Add(new SelectListItem() { Value = (i.ID).ToString(), Text = "收件人：" + i.AddressPerson + "；   收件地址：" + i.Address + "；    电话：" + i.MobiNumber});   
            };
           
            ViewBag.addperson = list;

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
            var deleteDetail = order.OrdelDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表中移除明细记录
            order.OrdelDetails.Remove(deleteDetail);

            //更新用户编辑的会话
            Session["Order"] = order;

            var totalPrice = (from item in order.OrdelDetails select item.Count * item.Album.Price).Sum();

            //重新生成Html脚本，返回json数据，局部刷新视图
            var htmlString = "";

            foreach (var item in order.OrdelDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td> " + item.Count + "</td> ";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"RemoveDetail('" + item.ID + "');\"> <i class=\"glyphicon glyphicon-remove\" ></i>我不喜欢这个了 抛弃！</a></td></tr>";
            }
            htmlString += "<tr><td colspan=\"4\" style=\"text-align:right\">总价格： <span style =\"color:red\" >" + totalPrice.ToString("C") + "<span/></td></tr>";

            return Json(htmlString);
        }
        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(string id)
        {
            //1.判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var order = new Order();
            order.Person = _context.Persons.Find(person.ID);

            //3.从会话中读出订单明细列表
            order.OrdelDetails = new List<OrdelDetail>();
            var details = (Session["Order"] as Order).OrdelDetails;
            foreach (var item in details)
            {
                item.Album = _context.Albums.Find(item.Album.ID);
                order.OrdelDetails.Add(item);
            }

            order.TotalPrice = (from item in order.OrdelDetails select item.Count * item.Album.Price).Sum();




            //4.如果表单验证通过，则保存order到数据库（锁定进程），跳转到Pay / AliPay
            
                //加锁
                LockedHelp.ThreadLock(order.ID);
                try
                {
                    _context.Order.Add(order);

                    //清空购物车
                    var carts = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();
                    foreach (var item in order.OrdelDetails)
                    {
                        _context.Cart.Remove(_context.Cart.SingleOrDefault(x => x.Album.ID == item.Album.ID));
                    }

                    _context.SaveChanges();
                   
                }
                catch
                {
                }
                finally
                {
                    LockedHelp.ThreadUnLocked(order.ID);
                }

                //跳转到支付页Pay/AliPay 
                return RedirectToAction("Alipay", "Pay", new { id = order.ID });
            

        }
        /// <summary>
        /// 游览用户订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //1.确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Order") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var Order = _context.Order.Where(x => x.Person.ID == person.ID).ToList();

           

            return View(Order);
        }
        [HttpPost]
        public ActionResult Index(Guid orderid)
        {
            //1.确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Order") });

            return RedirectToAction("Alipay", "Pay", new { id = orderid });
        }
    }
}