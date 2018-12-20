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

        public ActionResult ChangePassWord()
        {
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassWord(ChangePassWordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //输入合法，进行修改
                bool changePwdSuccessed;
                try
                {
                    var userManage =
                        new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                    var userName = (Session["loginUserSessionModel"] as LoginUserSessionModel).User.UserName;
                    var user = userManage.Find(userName, model.PassWord);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "原密码不正确");
                        return View(model);
                    }
                    else
                    {
                        //修改密码
                        changePwdSuccessed = userManage.ChangePassword(user.Id, model.PassWord, model.ConFirmPassWord)
                            .Succeeded;
                        if (changePwdSuccessed)
                            return Content("<script>alert('修改成功!');location.href='" + Url.Action("login", "Account") + "'</script>");
                        else
                            ModelState.AddModelError("", "修改密码失败，请重试");
                      
                    }
                }
                catch 
                {
                    ModelState.AddModelError("", "修改密码失败，请重试");
                }
            }
            
            return View(model);
        }

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
            if (ModelState.IsValid) 
            {
                var user = new Person()
                {
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    Name = model.FullName,
                    CredentialsCode = "4500002015010112345",
                    Birthday = DateTime.Parse("2015-01-01"),
                    Sex = true,
                    Email = model.Email,
                    TelephoneNumber = "13333158899",
                    MobileNumber = "1383388",
                    Description = "注册用户组",
                    UpdateTime = DateTime.Now,
                    CreateDateTime = DateTime.Now,
                    InquiryPassword = model.ConFirmPassWord
                };
                var s = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    ChineseFullName = model.FullName,
                    Email = model.Email,
                    MobileNumber = "13333158899",
                    Person = user
                };

                var idManger = new IdentityManager();
                idManger.CreateUser(s, model.ConFirmPassWord);
                idManger.AddUserToRole(s.Id, "RegisterUser");
                return Content("<script>alert('恭喜注册成功!');location.href='" + Url.Action("login", "Account") + "'</script>");
            }

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

        public ActionResult loginout()
        {
            Session.Remove("loginStatus");
            Session.Remove("loginUserSessionModel");
            return RedirectToAction("index", "Home");
        }
    }
}