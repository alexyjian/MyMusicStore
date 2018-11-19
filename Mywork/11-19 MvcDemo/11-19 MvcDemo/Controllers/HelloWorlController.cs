using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _11_19_MvcDemo.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            //return View("../../Views/Test/Test1");
            return View();
        }

        public ActionResult WelCome(string name,int id=1)                                          
        {
            ViewBag.ID = id;
            ViewBag.Name = name + ",你好!";
            Session["message"] = "这是主页啊!";
            return View();
        }
    }
}