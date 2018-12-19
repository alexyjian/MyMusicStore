using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _dbContext = new EntityDbContext();
        // GET: Store
        public ActionResult Detail(Guid id)
        {
            var detail = _dbContext.Albums.Find(id);
            if (Session["LoginUserSessionModel"] == null)
            {
                ViewBag.AvardaUrl = "/Content/Images/Body.jpg";
            }
            else
            {
                ViewBag.AvardaUrl = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Avarda;
            }
            return View(detail);
        }

        public ActionResult Browser(Guid id)
        {
            var list = _dbContext.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult Zan(Guid id)
        {
            return View();
        }
    }
}