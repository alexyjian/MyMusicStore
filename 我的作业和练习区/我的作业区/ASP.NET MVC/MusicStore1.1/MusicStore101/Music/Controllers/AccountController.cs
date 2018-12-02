using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Music.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;

namespace Music.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        ///登陆方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(string retunUrl=null)
        {
            if (string.IsNullOrEmpty(retunUrl))
            {
                ViewBag.ReturnUrl = Url.Action("index", "Home");
            }
            else
            {
                ViewBag.ReturnUrl = retunUrl;
            }
            return View();
        }
        [HttpPost]//此Action用来接收用户提交
        public ActionResult Login(LoginViewModel model,string returnUrl)
        {
            //判断实体是否校验通过
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误"
                };
                //登陆处理
                var userManage =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                var user = userManage.Find(model.Username, model.PassWord);
                if (user != null)
                {
                    var roleName = "";
                    var context=new EntityDbContext();
                    foreach (var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                    }

                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登陆成功!用户的角色:" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";
                    //把登陆状态保存到会话
                    Session["loginStatus"] = loginStatus;
                    var loginUserSessionModel=new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        Rolename=roleName
                    };
                    //把登陆成功后用户信息保存到会话
                    Session["loginUserSessionModel"] = loginUserSessionModel;
                    var identity = userManage.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    return Redirect(returnUrl);
                }
            }
            return View();
        }
    }
}