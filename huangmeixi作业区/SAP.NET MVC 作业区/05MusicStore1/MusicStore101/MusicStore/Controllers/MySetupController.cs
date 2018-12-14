using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using MusicStore.ViewModels;

namespace MusicStore.Controllers
{
    public class MySetupController : Controller
    {
        private static EntityDbContext _context = new EntityDbContext();
       
        public ActionResult Index()
        {
            //当前登录验证
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Order") });
            //当前用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;


            return View("MySetup");
        }

    }
}