using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ViewResult Index()
        {
            string[] Names = { "黄武健", "韦安妮", "银浩然","覃萱娜","黄学明" };
            string[] Powers = { "班长", "副班长", "团支书","宣传委员","心理委员" };
            ViewBag.Name = Names;
            ViewBag.Power = Powers;
            return View();
        }
    }
}