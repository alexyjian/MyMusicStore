using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore101.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            var list = context.Albums.OrderByDescending(x => x.PublisherDate).Take(50).ToList();
            return View(list);
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