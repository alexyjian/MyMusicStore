using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class Accuntcontroller : Controller
    {
        // GET: Accuntcontroller
        public ActionResult Index()
        {
            return View();
        }
              /// <summary>
              /// 登录方法
              /// </summary>
              /// <param name="returnUrl">登录成功后跳转地址</param>
              /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            return View();
        }
    }
}