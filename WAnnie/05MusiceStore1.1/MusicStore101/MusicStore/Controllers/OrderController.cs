using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;

namespace MusicStore.Controllers
{
    public class OrderController : Controller
    {

        public static readonly MusicContext _Context = new MusicContext();

        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            //1.确认登录是否登录，是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _Context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车的总价  ling表达式
            decimal? totalPrice = (from item in carts select item.Count * item.Ablum.Price).Sum();


            //3.创建新Order对象
            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _Context.Persons.Find(person.ID),
                TotalPrice = totalPrice ?? 0.00M,
            };

            //4.把购物项导入订单明细
            order.OrderDetails=new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail = new OrderDetail()
                {
                  AlbumID = item.AblumID,
                    Ablum = _Context.Ablums.Find(item.Ablum.ID),
                    Count = item.Count,
                    Price = item.Ablum.Price
                };
                order.OrderDetails.Add(detail);
            }
            //5.将订单和明细在视图呈现，验证用户收件人、地址、电话，供用户选择确认要购买的专辑
            //当前订单未持久化，用会话保存方便用户进行编辑
            Session["Order"] = order;
            return View(order);
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
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
        ///                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}