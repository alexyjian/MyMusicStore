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
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Order") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var orders = _Context.Orders.Where(x => x.Person.ID == person.ID).ToList();
            return View(orders);
        }

        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();

            var order = new Order()
            {
                Person = person,
                TotalPrice = (from item in carts select item.Count * item.Album.Price).Sum(),
                PaySuccess = false,
                EnumOrderStatus = EnumOrderStatus.未付款,
                PeopleAddress = _Context.PeopleAddress.SingleOrDefault(x => x.Person.ID == person.ID && x.IsClick == true)
            };
            order.AddressPerson = order.PeopleAddress.Name;
            order.Address = order.PeopleAddress.Address;
            order.mobilNumber = order.PeopleAddress.MobileNumber;

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
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(Order order)  
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            order.Person = _Context.Persons.Find(person.ID);
            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in (Session["Order"] as Order).OrderDetails)
            {
                item.Album = _Context.Albums.Find(item.Album.ID);
                order.OrderDetails.Add(item);
            }
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            if (ModelState.IsValid)
            {
                LockHelp.ThreadLocked(order.ID);
                try
                {
                    //订单数据持久化
                    _Context.Orders.Add(order);
                    _Context.SaveChanges();

                    //清空购物车
                    foreach (var item in order.OrderDetails)
                    {
                        var removecart = _Context.Carts.SingleOrDefault(x => x.Album.ID == item.Album.ID);
                        _Context.Carts.Remove(removecart);
                    }
                    _Context.SaveChanges();
                }
                catch { }
                finally
                {
                    LockHelp.ThreadUnLocked(order.ID);
                }
                return RedirectToAction("Alipay", "Pay", new { id = order.ID });
            }
            return View();
        }

        /// <summary>
        /// 移除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            if (Session["Order"] == null)
                return RedirectToAction("Buy", "Order");

            var order = Session["Order"] as Order;
            //在会话中查询明细
            var delDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            order.OrderDetails.Remove(delDetail);
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            string htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }
            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ order.TotalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }

        /// <summary>
        /// 增加数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCount(Guid id)
        {
            if (Session["Order"] == null)
                return RedirectToAction("Buy", "Order");

            var order = Session["Order"] as Order;
            //在会话中查询明细
            var Detail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            Detail.Count++;
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            string htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }
            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ order.TotalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }

        /// <summary>
        /// 减少数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MinusCount(Guid id)
        {
            if (Session["Order"] == null)
                return RedirectToAction("Buy", "Order");

            var order = Session["Order"] as Order;
            //在会话中查询明细
            var Detail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            if (Detail.Count > 1)
                Detail.Count--;
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            string htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }
            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ order.TotalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }
    }
}