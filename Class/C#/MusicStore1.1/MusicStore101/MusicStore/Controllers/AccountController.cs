using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var idManger = new IdentityManager();

                var person = new Person()
                {
                    FirstName = model.FullName[0].ToString(),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    Name = model.FullName,
                    Email = model.Email,
                    Birthday = DateTime.Now,
                    Avarda = "/Content/Images/Body.jpg",
                    Description = "用户注册"
                };

                var registerUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FullName[0].ToString(),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    ChineseFullName = model.FullName,
                    Email = model.Email,
                    Person = person
                };

                idManger.CreateUser(registerUser, model.PassWord);
                idManger.AddUserToRole(registerUser.Id, "RegisterUser");
            }
            return Content("<script>alert('用户注册成功！');location.href='" + Url.Action("Login", "Account") + "'</script>");
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="returnUrl">登录成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnUrl = Url.Action("Index", "Home");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View();
        }

        [HttpPost]      //此Login用来接收用户的提交
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginStatu = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误"
                };

                var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
                var user = usermanager.Find(model.UserName, model.PassWord);

                if (user != null)
                {
                    var roleName = "";
                    var context = new MusicStoreEntity.EntityDbContext();
                    foreach (var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                    }
                    loginStatu.IsLogin = true;
                    loginStatu.Message = "登录成功，用户的角色" + roleName;
                    loginStatu.GotoController = "Home";
                    loginStatu.GotoAction = "Index";

                    //保存登录状态
                    Session["loginStatus"] = loginStatu;

                    var loginUserSessionModel = new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName
                    };

                    //保存登录成功后的信息
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    //identity登录处理，创建ASP.NET的登录令牌Token
                    var identity = usermanager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    return Redirect(returnUrl);
                }
                else
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        ViewBag.ReturnUrl = Url.Action("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ReturnUrl = returnUrl;
                    }
                    ViewBag.LoginUserStatus = loginStatu;
                    return View();
                }

            }
            if (string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnUrl = Url.Action("Index", "Home");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View();
        }

        public ActionResult LoginOut()
        {
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("Index", "Home");
        }
    }
}