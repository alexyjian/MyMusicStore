using MusicStore.ViewModels;
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

        // GET: My
        public ActionResult Index()
        {
            //1.判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            //2.读出当前用户person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var myVM = new MyViewModel()
            {
                Name = person.Name,
                Address = person.Address,
                TelePhoneNumber = person.TelephoneNumber

            };
            ViewBag.AVARDAuRL = person.Avarda;

            return View(myVM);
        }
    }
}