using MusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyInfoController : Controller
    {
        // GET: MyInfo
        public ActionResult Index(MyInfoViewModel myinfo)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "MyInfo") });
            //查询出当前用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;




            return View();

        }
    }
}