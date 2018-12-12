﻿using MusicStore.ViewModels;
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
            if (Session["Order"] == null)
                return RedirectToAction("Buy", "Order");

            var order = Session["Order"] as Order;
            _Context.Orders.Add(order);
            foreach (var item in order.OrderDetails)
                _Context.OrderDetails.Add(item);
            _Context.SaveChanges();

            return RedirectToAction("");
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
                return RedirectToAction( "Buy", "Order");

            var order = Session["Order"] as Order;
            //查询是否有某用户的某购物车单
            var delDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            order.OrderDetails.Remove(delDetail);
            decimal totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            string htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }
            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ totalPrice.ToString("C")} </td></tr>";

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
            //查询是否有某用户的某购物车单
            var Detail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            Detail.Count++;
            decimal totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            string htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }
            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ totalPrice.ToString("C")} </td></tr>";

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
            //查询是否有某用户的某购物车单
            var Detail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            if (Detail.Count > 1)
                Detail.Count--;
            decimal totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            string htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }
            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ totalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }
    }
}