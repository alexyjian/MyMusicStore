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

        /// <summary>
        /// 填写注册信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            //用户的保存 person ApplicationUser
            var idManger = new IdentityManager();
            var user=new Person()
            {
                FirstName = model.FullName,
                LastName = model.FullName,
                Name = model.FullName,
                Sex = true,
                Email = model.Email,
                CredentialsCode = "4500002015010112345",
                Birthday = DateTime.Parse("2015-01-01"),
                Description = "注册用户组",
                TelephoneNumber = "3158899",
                UpdateTime = DateTime.Now,
                InquiryPassword = model.ConFirmPassWord
            };
            var s= new  ApplicationUser()
            {
                UserName = model.UserName,
                FirstName = model.FullName,
                LastName = model.FullName,
                ChineseFullName = model.FullName,
                Email = model.Email,
                Person =user
            };
            idManger.CreateUser(s, model.ConFirmPassWord);
            idManger.AddUserToRole(s.Id, "RegisterUser");
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
        [ValidateAntiForgeryToken]
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