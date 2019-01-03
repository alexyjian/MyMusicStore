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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel mode)
        {
            if (ModelState.IsValid)
            {
                var person1 = new Person()
                {
                    FirstName = mode.FullName.Substring(1, 0),
                    LastName = mode.FullName[mode.FullName.Length - 1].ToString(),
                    Name = mode.FullName,
                    Birthday = DateTime.Parse("2000-2-22"),
                    Email = mode.Email,
                    Description = "普通用户注册",
                    CreateDateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                };
                var idManger = new IdentityManager();
                var loginUser = new ApplicationUser()
                {
                    UserName = mode.UserName,
                    FirstName = mode.FullName.Substring(0, 1),
                    LastName = mode.FullName.Substring(1, mode.FullName.Length - 1),
                    ChineseFullName = mode.FullName,
                    Email = mode.Email,
                    Person = person1
                };

                idManger.CreateUser(loginUser, mode.PassWord);
                idManger.AddUserToRole(loginUser.Id, "Admin");

            }
            return Content("<script>alert('恭喜注册成功!');location.href='" + Url.Action("login", "Account") + "'</script>");
            //return Redirect("~/Account/Login");

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl">登录成功后跳的地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
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

        public ActionResult ChangePassword()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login");

            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
            var userName = (Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName;
            if (ModelState.IsValid)
            {
                bool changePwdSuccessed;
                try
                {

                    var user = userManage.Find(userName,model.PassWord);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "需要修改的密码错误");
                        return View();
                    }
                    else
                    {
                        changePwdSuccessed= userManage.ChangePassword(user.Id, model.PassWord, model.NewPassWord).Succeeded;
                        if (changePwdSuccessed)
                            return Content("<script>alert('修改成功!');location.href='" + Url.Action("index", "Home") + "'</script>");
                        else
                            ModelState.AddModelError("", "需要修改的密码错误");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "需要修改的密码错误");
                }
            }
            return View(model);
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Loginout()
        {
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("index", "Home");
        }

        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
        private readonly EntityDbContext _context = new EntityDbContext();
     
    
    }
}