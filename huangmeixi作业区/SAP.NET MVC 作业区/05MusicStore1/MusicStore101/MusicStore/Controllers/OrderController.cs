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
            //确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Accoount", new { returnUrl = Url.Action("Buy","Order")});

            //查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();

            //算购物车的总价
            decimal?totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            //创建新Order对象

            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
                TotalPrice = totalPrice??0.00m,
            };
            //把购物车项导入订单明细
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

            //将订单和明细在视图呈现，验证用户收件人、地址、电话、供用户选择确认要购买的专辑

            //当前订单未持久化，用会话保存方便用户进行编辑
            Session["Order"] = order;
            return View(order);
        }
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空,则重新刷新页面
            if (Session["Order"] == null)
                return RedirectToAction("buy");

            //读取会话中的Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表中移除明细记录
            order.OrderDetails.Remove(deleteDetail);

            //根据新的order对象重新生成Html脚本,返回json数据,局部刷新视图
            var htmlString = "";
            //订单总价
            var totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href ='" + Url.Action("Detail", "Store", new { id = item.Album.ID }) + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href='#'onclick ='RemoveDtail('" + item.ID + "');'><i class='glyphicon glyphicon-remove'></i>移出购物车</a></td>";
                htmlString += "</tr>";
            }
            htmlString += "<tr><td></td><td></td><td>总价</td><td>" + order.TotalPrice.ToString("C") + "</td></tr>";

            return Json(htmlString);
        }
        /// <summary>
        /// 处理提交下单
        /// </summary>
        /// <param name="Oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order Oder)
        {
            return View();
        }


        /// <summary>
        /// 浏览用户提交下单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}