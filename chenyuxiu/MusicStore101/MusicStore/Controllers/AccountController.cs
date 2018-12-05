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
/// <summary>
/// 注册登录
/// </summary>
/// <param name="model"></param>
/// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(ReadEntityBodyMode model)
        {
            //用户的保存 Person ApplicaonUser
            //var detail = _context.Albums.Find(id);
            //return View(detail);
            return View();
        }
        /// <summary>
        /// 登入方法
        /// </summary>
        /// <param name="returnUrl">登入成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            //var account = _context.Albums.Find(id);
            //return View(account);
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost] //此Action用来接收用户提交
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //return Json("OK");
            //判断实体是否校验成功
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误！",

                };
                //登录处理
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
                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登入成功！用户的角色：" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";
                    Session["loginStatus"] = loginStatus;

                    var loginUserSessionModel = new LoginUserSeesionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName,
                    };
                    //把登入成功后用户信息保存到会话
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    //identity登入处理，创建aspnet的登录令牌Token
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