﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo1.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
            //return View("../../Views/Test/test1");
        }

        public ActionResult Welcome(string name,int id=1)
        {
            ViewBag.ID = id;
            ViewBag.Name = name + ",您好！";
            Session["message"] = "原谅爸爸好吗！！！";
            return View();
        }
    }
}