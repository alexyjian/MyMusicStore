using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.Models;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MusicStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
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
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]//此Action用来接收用户提交
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //判断实体是否校验通过
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误",
                };
                //登录处理
                var userManage = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(new EntityDbContext()));
                var user =userManage.Find(model.Password,)
            }
            return View ();
        }
    }
}