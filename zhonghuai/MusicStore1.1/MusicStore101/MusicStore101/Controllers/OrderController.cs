﻿using MusicStore101.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore101.Controllers
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

            //1.确认用户是否登录，是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();  //linq表达式 一句完成


            //3.创建新Order对象，验证用户收件人、地址、电话


            //4.把购物项导入订单明细，供用户选择确认要购买专辑


            //将订单何明细在视图呈现，验证用户收件人、地址、电话、供用户选择确认要购买的专辑

            return View();
        }

        [HttpPost]
        public ActionResult RemoveDetail (Guid id)
        {
            return Json("");
        }
        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <returns></returns>
        // GET: Order
        public ActionResult Buy(Order oder)
        {
            return View();
        }

        /// <summary>
        /// 浏览用户
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}