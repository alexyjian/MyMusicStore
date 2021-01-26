using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: test
        public ActionResult Index()
        {
            var context = new MusicContext().Albums.OrderByDescending(x=>x.PublisherDate).Take(20).ToList();
            return View(context);
        }
    }
}