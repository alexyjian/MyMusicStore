using MusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MusicStore.Controllers.HomeController.HomeController;

namespace MusicStore.Controllers
{
    public class AccountControllerController : Controller
    {
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="returnUrl"> 登录成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            return View();
        }
        [HttpPost]//此Action用来接收用户提交
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            return Json("OK");
        }
    }
}