using System;
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
            //return View("../../Views/View");
            return View();
        }
        public ActionResult Welcome(string name,int id)
        {
            ViewBag.ID = id;
            ViewBag.Name = name + "，你好！";
            Session["message"] = "今天天气不错！！！";
            Session["max"] = 2222222222222;
            Session["min"] = "今天也很欧啊";
            return View();
        }
    }
}