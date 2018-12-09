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
                    Album=_context.Albums.Find(i.Album.ID),
                    Count =i.Count,
                    Price=i.Album.Price
                };
                order.OrdelDetails.Add(detail);
            }

            //将订单和明细在视图呈现 验证用户收件人、地址、电话 供用户选择确认要购买的专辑

            //当前订单未持久化，用会话保存方便用户编辑
            Session["Order"] = order;

            return View(order);
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            var cartItem = _context.OrdelDetail.Find(id);
            _context.OrdelDetail.Remove(cartItem);
            return Json("");
        }
        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Order(Order oder)
        {
            return View();
        }
        /// <summary>
        /// 游览用户订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}