using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
using MusicStoreEntities.UserAndRole;
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
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登陆方法
        /// </summary>
        /// <param name="returnUrl">登陆成功后跳转地址</param>
        /// <returns></returns>

        public ActionResult Login(string returnUrl=null )
        {
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]//此Action用来接收用户提交
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //判断实体是否校验通过
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误"
                };
                //登陆处理
                var userManage =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                var user = userManage.Find(model.UserName, model. PassWord);
                if (user != null)
                {
                    var roleName = "";
                    var context = new EntityDbContext();
                    foreach (var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";

                    }

                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登陆成功！用户的角色：" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";

                    Session["loginStatus"] = loginStatus;

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
                ViewBag.RetumUrl = returnUrl;
            return View();
        }

       
    }
}