﻿using System;
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
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空，则重新刷新页面
            if (Session["Order"] == null)
            {
                return RedirectToAction("buy");
            }
            //读取会话中的Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x=>x.ID==id);
            //从订单明细列表中移除明细纪录
            order.OrderDetails.Remove(deleteDetail);
            
            //根据新的order对象,重新生成Html脚本，返回json数据，局部刷新视图


            //订单总价
            var totalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum(); //Linq表达式
            var htmlString = "";
            //更新保存会话
            Session["Order"] = order;
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='" +Url.Action("Detail","Store",new {id = item.Album.ID }) + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td><i style=\"cursor: pointer\" class=\"glyphicon glyphicon-plus\" onclick=\"plus('" + item.ID + "')\"></i> " + item.Count + " <i  style=\"cursor: pointer\" class=\"glyphicon glyphicon-minus\" onclick=\"minus('" + item.ID + "')\"></i></td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeDetail('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\">移除购物车</i></a></td>";
            }
            htmlString += "<tr><td></td><td></td ><td>总价</td><td>" + totalPrice.ToString("C") + "</ td ></ tr >";

            return Json(htmlString);
        }
        /// <summary>
        /// 处理用户提交订单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }
            //2.读出当前用户Person

            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;


            //3.从会话中读出订单明细列表

            var order = Session["Order"] as Order;

            //4.如果表单验证通过，则保存order到数据库()，跳转到Pay/AliPay

            var od = new Order()
            {
                AddresPerson = oder.AddresPerson,
                Mobilnumber = oder.Mobilnumber,
                Person = person,
                TotalPrice = order.TotalPrice
            };
            _context.Orders.Add(od);

            //5.如果验证不通过，返回视图

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