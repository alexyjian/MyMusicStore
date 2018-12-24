using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class UeditorController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: Ueditor
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Guid id,string Reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            //查出出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;


            var reply = new Reply()
            {
                Album = _context.Albums.Find(id),
                Person = _context.Persons.Find(person.ID),
                Content = Reply
            };

            _context.Reply.Add(reply);
            _context.SaveChanges();
            return View(reply);
        }
    }
}