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
            return View("../../Views/Test/Test");

            //return View();

        }
        public ActionResult Welcome(string name,int id=1)
        {
            //return "这是我的<b>欢迎</b>控制器方法(action)";
            //return "你好，" + name + "，欢迎次数：" + numtimes;
            ViewBag.ID = id;
            ViewBag.name = name+",您好!";
            Session["message"] = "明天会更好！";
            return View();
        }
    }
}