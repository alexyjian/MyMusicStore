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
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        // GET: Store
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var detail = _context.Albuns.Find(id);
            ViewBag.detail = detail;
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            try { ViewBag.Reply = _context.Replys.Where(x => x.Album.ID == id && x.Person.ID == person.ID).ToList(); }
            catch { }

            return View();
        }
        //
        public ActionResult browser(Guid id)
        {
            var list = _context.Albuns.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublsherDate).ToList();
            return View(list);
        }

        public ActionResult Index()
        {

            var list = _context.Genres.OrderByDescending(x => x.Name).ToList();
            var list1 = _context.Albuns.OrderByDescending(x => x.PublsherDate).ToList();

            return View(list);

        }

        [HttpPost]
        public ActionResult Reply(Guid id, string content)
        {
            var reply = new Reply()
            {
                Content = content,
                Album = _context.Albuns.Find(id),
                 Person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID),
        };
            _context.Replys.Add(reply);
            _context.SaveChanges();
            return View(123);
        }
    }
}