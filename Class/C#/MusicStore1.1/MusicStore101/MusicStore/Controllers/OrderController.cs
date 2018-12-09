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
        private static readonly EntityDbContext _Context = new EntityDbContext();
        /// <summary>
        /// 浏览用户订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();

            var order = new Order()
            {
                Person = person,
                AddressPerson = person.Name,
                mobilNumber = person.TelephoneNumber,
                TotalPrice = (from item in carts select item.Count * item.Album.Price).Sum(),
                PaySuccess = false,
                EnumOrderStatus = EnumOrderStatus.未付款
            };

            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in carts)
            {
                var od = new OrderDetail()
                {
                    AlbumID = item.AlbumID,
                    Album = item.Album,
                    Count = item.Count,
                    Price = item.Count * item.Album.Price
                };
                order.OrderDetails.Add(od);
            }
            Session["Order"] = order;
            return View(order);
        }

        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(Order oder)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询是否有某用户的某购物车单
            var odItem = _Context.OrderDetails.Find(id);
            _Context.OrderDetails.Remove(odItem);
            
            return Json("");
        }
    }
}