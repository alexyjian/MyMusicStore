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
            if (Session["LoginUserSessionModel"] == null)
            return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Cart.Where(x => x.Person.ID == x.Person.ID).ToList();
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            var orders = new Order() {
                AdderssPerson = person.Name,
                MobiNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
                TotaPrice=totalPrice??0.00M,
                Address=person.Address,
            };

            orders.OrderDetails = new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail = new OrderDetail() {
                    AlbumID = item.AlbumID,
                    Album = _context.Albums.Find(item.Album.ID),
                    Count =item.Count,
                    Price=item.Album.Price
                };
                orders.OrderDetails.Add(detail);
            }
            Session["order"] = orders;
            return View(orders);
        }
      
        [HttpPost]
        public ActionResult Buy(Order order)
        {
            //判断用户凭据是否过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("Buy", "Order") });

            //读出当前用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            order.Person = _context.Persons.Find(person.ID);

            //读出订单明细列表
            order.OrderDetails = new List<OrderDetail>();
            order.TotaPrice = 0.00M;
            var details = (Session["Order"] as Order).OrderDetails;
            foreach (var item in details)
            {
                item.Album = _context.Albums.Find(item.Album.ID);
                order.OrderDetails.Add(item);
            }
            order.TotaPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            //验证通过，保存到数据库，跳转到Pay/Alipay
            if (ModelState.IsValid)
            {
                //加锁
                LockedHelp.ThreadLock(order.ID);
                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    //清空购物车
                    var carts = _context.Cart.Where(x => x.Person.ID == x.Person.ID).ToList();
                    foreach(var cart in carts)
                    {
                        _context.Cart.Remove(cart);
                    }
                    _context.SaveChanges();
                    var p = _context.Persons.Find(person.ID);
                    p.MobileNumber = order.MobiNumber;
                    p.Address = order.Address;
                    p.Name = order.AdderssPerson;
                    p.FirstName = p.Name.Substring(0, 1);
                    p.LastName = p.LastName.Substring(1, p.Name.Length - 1);
                    _context.SaveChanges();
                }
                catch
                {

                }
                finally
                {
                    LockedHelp.ThreadUnLocked(order.ID);
                }
                return RedirectToAction("AliPay", "Pay", new { id = order.ID });
            }

            //不通过验证返回视图
            return View();
        }
        /// <summary>
        /// 浏览用户订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pay");
        }
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            if (Session["Order"] == null)
                return RedirectToAction("buy");

            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);

            order.OrderDetails.Remove(deleteDetail);

            var htmlString = "";

            order.TotaPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            Session["Order"] = order; 
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr><th class=\"Cart-tbody-th\"><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></th>";
                htmlString += "<th>" + item.Album.Price.ToString("C") + "</th>";
                htmlString += "<th>&nbsp;" + item.Count + "&nbsp;</th>";
                htmlString += "<th class=\"Cart-tbody-th\">   <a class='glyphicon glyphicon-remove Cartdelete' onclick=\"RemoveDetail('"+item.ID+"')\"><span>删除此项</span></a></th><tr>";
            }
            htmlString += "<tr><th ></th><th></th><th></th><th  class=\"totalprice - th\" colspan=\"4\">总价" + order.TotaPrice.ToString("C") + "</th ></tr>";
            return Json(htmlString);
        }
    }
}