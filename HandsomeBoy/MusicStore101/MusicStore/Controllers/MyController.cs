﻿using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        // GET: My
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            //var list = _context.Mys.OrderBy(x => x.Address).ToList();
            //Session["Order"] = list;
            return View();
        }

        [HttpPost]
        public ActionResult Add(MusicStoreEntity.My model)
        {
           
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var my = new My()
            {
                AddressPerson = model.AddressPerson,
                Area = model.Area,
                MobiNumber = model.MobiNumber,
                Email = model.Email,
 Person = _context.Persons.Find(person.ID)
            };
            //Session["MyAdd"] = my;
            _context.Mys.Add(my);
            _context.SaveChanges();
            return Content("<script>alert('添加地址成功!');location.href='" + Url.Action("Index", "My") + "'</script>");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Remove(Guid id)
        {

            return View();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
        {

            return View();
        }
    }
}