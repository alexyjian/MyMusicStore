using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
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
        /// 
        /// </summary>
        /// <param name="returnUrl">登录成功后跳的地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl=null )
        {
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    Islogin = false,
                    Message = "用户或密码错误",
                };
                var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
            var user = userManage.Find(model.UserName, model.PassWord);
            if (user != null)
            {
                var roleName = "";
                var context = new EntityDbContext();
                foreach (var role in user.Roles)
                {
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                }
                    loginStatus.Islogin = true;
                    loginStatus.Message = "登录成功" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";

                    Session["LoginUserSessionModel"] = loginStatus;
                    var loginUserSessionModel = new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName,
                    };                
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    var identity = userManage.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    return Redirect(returnUrl);
                }
                else
                {
                    if (string.IsNullOrEmpty(returnUrl))
                        ViewBag.ReturnUrl = Url.Action("index", "home");
                    else
                        ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginUserStatus = loginStatus;
                    return View();
                }
            }
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}