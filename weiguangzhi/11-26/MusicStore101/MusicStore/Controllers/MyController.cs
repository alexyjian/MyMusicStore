﻿using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: My
        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "my") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var orders = Session["Order"] as Order;
            //3.创建新Order对象
            var my = new MyViewModel()
            {
                Name=person.Name,
                Address=person.Address,
                MobilNumber = person.MobileNumber,
           

            };

            ViewBag.AvardaUrl = person.Avarda;

            return View(my);

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewModel model)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "my") });
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);


            var oldAvarda = person.Avarda;

            if (ModelState.IsValid)
            {
                //保存头像
                if (model.Avarda != null)
                {
                    var uploadDir = "~/Upload/Avarda/";
                    //取后缀名
                    var fileLastName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".") + 1,
                        (model.Avarda.FileName.Length - model.Avarda.FileName.LastIndexOf(".") - 1));
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID + "." + fileLastName);  //将网站虚拟路径转化为真实的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda = "/Upload/Avarda/" + person.ID + "." + fileLastName;
                }

                //把订单中的收件人信息保存带person中
               
                person.MobileNumber = model.MobilNumber;
                person.Address = model.Address;
                person.Name = model.Name;
                person.FirstName = person.Name.Substring(0, 1);
                person.LastName = person.Name.Substring(1, person.Name.Length - 1);
                person.Birthday = model.Birthday;
                person.Sex = model.Sex;
                person.Avarda = oldAvarda;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.AvardaUrl = oldAvarda;
            return View();
        }
    }
}