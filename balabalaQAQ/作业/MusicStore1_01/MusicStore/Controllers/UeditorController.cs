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
        public ActionResult Index(Guid id,string Reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            //查出出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var carts = _context.Reply.Where(x => x.Person.ID == person.ID).ToList();
            return View();
        }
    }
}