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
            try { ViewBag.Reply = _context.Replys.Where(x => x.Album.ID == id).OrderBy(x=>x.CreateDateTime).ToList(); }
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
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var list = _context.Genres.OrderByDescending(x => x.Name).ToList();
            var list1 = _context.Albuns.OrderByDescending(x => x.PublsherDate).ToList();

            return View(list);

        }

        [HttpPost]
        public ActionResult Reply(Guid id,string content,string html)
        {
           
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var reply = new Reply()
            {
                Content = content,
                Album = _context.Albuns.Find(id),
                 Person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID),
               
            };
            //reply.ParentReply = reply;
          _context.Replys.Add(reply);
            _context.SaveChanges();
            var list  = new  List<Reply>();
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            try { list = _context.Replys.Where(x => x.Album.ID == id).OrderBy(x => x.CreateDateTime).ToList(); }
            catch { }

            var htmlString = "";
            foreach (var item in list)
            {
                htmlString+= "<div class=\"comment\">";
                htmlString += " <img src="+item.Person.Avarda+">";
                    htmlString += "<span>" + item.Person.Name+ "</span>";
                htmlString += " <span>" + item.Content + "</span>";
                htmlString += "<p>" + item.CreateDateTime + "</p>";
               
                htmlString += "<a href=\"javascript:; \" >回复</a>";
                htmlString += "</div>";
            }
           
            return Json(htmlString);
        }
    }
}