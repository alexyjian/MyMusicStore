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
            ViewBag.AvardaUrl = Session["LoginUserSessionModel"] == null ? "/Content/Images/Body.jpg": (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Avarda;

            return View(detail);
        }

        public ActionResult Browser(Guid id)
        {
            var list = _dbContext.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }

        public ActionResult Commit(string content)
        {
            return View();
        }

        public ActionResult Zan(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Order") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var commentary = _dbContext.Commentarys.Find(id);
            commentary.ThumbsUp++;
            _dbContext.SaveChanges();
            var htmlString = "";
            htmlString = "<span class='glyphicon glyphicon-thumbs - up'></span>&nbsp;&nbsp;( " + commentary.ThumbsUp + " )";
            return Json(htmlString);
        }
    }
}