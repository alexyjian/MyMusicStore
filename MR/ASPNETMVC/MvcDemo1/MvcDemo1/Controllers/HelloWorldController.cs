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
            return View();
        }
        public ActionResult Welcome(string name,int id=1)
        {
            ViewBag.ID = id;
            ViewBag.Name = name+"您好";
            return View();
        }
    }
}