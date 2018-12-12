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
                Address = person.Name,
                MobiNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
                TotaPrice=totalPrice??0.00M,
            };
            orders.OrderDetails = new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail = new OrderDetail() {
                    AlbumID = item.AlbumID,
                    Album = item.Album,
                    Count=item.Count,
                    Price=item.Album.Price
                };
                orders.OrderDetails.Add(detail);
            }
            Session["order"] = orders;
            return View(orders);
        }
      
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            //判断用户凭据是否过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
            //读出当前用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //读出订单明细列表

            //验证通过，保存到数据库，跳转到Pay/Alipay

            //不通过验证返回视图
            return View();
        }
        /// <summary>
        /// 浏览用户订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            if (Session["Order"] == null)
                return RedirectToAction("buy");

            var order = Session["Order"] as Order;

            var deleDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            order.OrderDetails.Remove(deleDetail);
            var htmlString = "";
            order.TotaPrice = (from item in order.OrderDetails
                              select item.Count * item.Album.Price).Sum();
            Session["Order"] = order;
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a><td/>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>移出购物车</a></td><tr>";

            }
            htmlString += "<tr><td ></td><td></td><td>总价</td><td>" + order.TotaPrice.ToString("C") + "</td ></tr>";

            return Json(htmlString);
        }
    }
}