
using MusicStore.ViewMoldels;
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

        /// <summary>
        /// 我的收获地址
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            //确认用户是否登录 是否登录过期
            if (Session["loginUserSessionModel"] == null)
            return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
                 var myVM= new MyViewModel()
                {
                     Name = person .Name,
                    Address = person.Address,
                    MobilNumber = person.MobileNumber  
                };
            ViewBag.AvardaUrl = person.Avarda;

          return View(myVM);
        }
    }
}