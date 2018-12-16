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
        private static readonly EntityDbContext _context = new EntityDbContext();

        public ActionResult Index()
        {
            //检查用户是否登录 登录是否过期
            if (Session["LoginUserSessionModel"] ==null)
                return RedirectToAction("login","Account",new {returUrl =Url.Action("Index","Order")});


            return View();
        }
    }
}