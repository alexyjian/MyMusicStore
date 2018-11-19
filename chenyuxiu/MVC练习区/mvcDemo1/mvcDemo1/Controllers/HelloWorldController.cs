using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDemo1.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View("../../Views/Test/Test");
        }

        public ActionResult Welcome(string name,int id=1)
        {
            return View();
        }
        public ActionResult Welcome1(string name, int id = 1)
        {
            ViewBag.ID = id;
            ViewBag.Name = name +",您好！";
            Session["message"] = "今天天气不错!!!!";
            return View();
        }
    }
}