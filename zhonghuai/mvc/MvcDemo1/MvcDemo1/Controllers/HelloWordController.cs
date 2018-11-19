using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo1.Controllers
{
    public class HelloWordController : Controller
    {
        // GET: HelloWord
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome(string name, int id = 1)
        {
            ViewBag.ID = id;
            ViewBag.Name = name + "你好";
            return View();
        }
    }
}