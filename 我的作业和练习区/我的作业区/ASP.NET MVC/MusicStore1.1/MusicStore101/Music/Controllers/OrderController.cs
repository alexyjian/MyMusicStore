using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using Music.ViewModels;

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
            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            //计算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum(); //Linq表达式
            //3.创建新Order对象
            var  order=new Order()
            {
                AddresPerson = person.Name,
                Mobilnumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
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

        public ActionResult RemoveDetail(Guid id)
        {
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }
            return Json("");
        }
        /// <summary>
        /// 处理用户提交订单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            return View();
        }
        /// <summary>
        /// 浏览用户订单
        /// </summary>
        /// <returns></returns>
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
    }
}