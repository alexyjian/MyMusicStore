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
            return View(/*"../../Views/Home/about"*/);
        }

        public ActionResult WelCome(string name, int id = 1)
        {

            ViewBag.ID = id;
            ViewBag.Name = name + ",你好";
            Session["message"] = "今天天气不错";
            return View();
        }

    }
}