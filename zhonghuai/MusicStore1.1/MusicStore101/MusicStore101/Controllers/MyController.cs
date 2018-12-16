using MusicStore101.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore101.Controllers
{
    public class MyController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // 修改个人信息
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;


            var myVm = new MyViewModel()
            {
                Name = person.Name,
                Address = person.Address,
                MobilNumber = person.MobileNumber
            };
            ViewBag.AvardaUrl = person.Avarda;

            return View(myVm);

        }
    }
}