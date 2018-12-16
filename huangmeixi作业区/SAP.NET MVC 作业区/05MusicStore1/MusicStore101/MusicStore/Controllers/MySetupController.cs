using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        public ActionResult Index()
        {

            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
             return View();
        }
        [HttpPost]
        public ActionResult Add(MusicStoreEntity.My model)
        {
            return View();
        }
    }
}
