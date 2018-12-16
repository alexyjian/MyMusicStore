using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using MusicStore.ViewModels;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        private static readonly EntityDBContext _context = new EntityDBContext();
        // 修改个人信息
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new {returnUrl=Url.Action("Index","My")});

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var myVM = new MyViewModel()
            {
                Name = person.Name,
                Address = person.Address,
                MobilNumber = person.MobileNumber
            };
            ViewBag.AvardaUrl = person.Avarda;
              return View(myVM);
        }
    }
}