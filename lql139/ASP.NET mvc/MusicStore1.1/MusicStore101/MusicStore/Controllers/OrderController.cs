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
                    Album = _context.Albums.Find(item.ID),
                    Count=item.Count,
                    Price=item.Album.Price
                };
                orders.OrderDetails.Add(detail);
            }
            Session["order"] = orders;
            return View(orders);
        }
        public ActionResult RemoveDetail(Guid id)
        {
            return Json("");
        }
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
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
    }
}