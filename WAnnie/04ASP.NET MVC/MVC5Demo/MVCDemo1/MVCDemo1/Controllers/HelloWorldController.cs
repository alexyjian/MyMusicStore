using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo1.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            //路径不一样的视图
            //return View("../../Views/Test/test1"); 
            return View();
        }
        public ActionResult Welcome(string name,int id=1)
        {
            //传值
            ViewBag.ID = id;
            ViewBag.Name = name + " ,你好!";
            Session["message"] = "明天你好!!!";
            return View();
        }

    }
}