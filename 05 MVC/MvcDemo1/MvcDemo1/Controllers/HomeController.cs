using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo1.Models;

namespace MvcDemo1.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //GET:Movies
        public ActionResult Index()
        {
            //强类型模型传入数据到试图
            return View(db.Movies.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}