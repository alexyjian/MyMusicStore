using System;
using MusicStore.ViewMoldels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{

    public class AccountController : Controller
    {
       
        /// <summary>
        /// 填写注册信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost] //此Action用来接收用户提交
        //阻止防止伪造请求的特性
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model )
        {
            //新用户的数据引用
            if(ModelState.IsValid)
            {
                var person = new Person()
                {
                    FirstName = model.FullName.Substring(0,1),
                    LastName = model .FullName .Substring (1,model.FullName.Length-1),
                    CredentialsCode = "452222199821566789",
                    Name  = model.FullName,
                    Birthday = DateTime.Now,
                    Sex = false,
                    MobileNumber = "18346464645",
                    Email = model.Email,
                    TelephoneNumber = "35346557787",
                    CreateDateTime = DateTime.Now,
                    Description = "注册用户",
                    UpdateTime = DateTime.Now,
                    InquiryPassword = "未设置 ",
                };

                var user = new ApplicationUser()
                {
                    UserName = model .UserName,
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length-1),
                    ChineseFullName = model .FullName,
                    MobileNumber = "18346464645",
                    Email = model .Email ,
                    Person = person,

                };

                var idManage = new IdentityManager();
                idManage.CreateUser(user, model.PassWord);
                idManage.AddUserToRole(user.Id, "RegisterUser");

                return Content("<script>alert('注册成功'); location.href='" +Url.Action("login","Account") +"'</script >");
            }

            return View();
        }


        /// <summary>
        /// 登录页面
        /// </summary>
        /// <param name="returnUrl">登录成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            //没有地址就跳转回首页
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost] //此Action用来接收用户提交
        //阻止防止伪造请求的特性
        [ValidateAntiForgeryToken]
        public ActionResult Login (LoginViewModel model,string returnUrl)
        {
            //判断实体是否校验通过
            if(ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误",
                };
                //登录处理
                var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                var user = userManage.Find(model.UserName, model.PassWord);
                if(user != null)
                {
                    var roleName = "";
                    var context = new EntityDbContext();
                    foreach (var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                    }

                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登录成功！用户的角色：" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";
                    //登录状态保存到回话
                    Session["loginStatus"] = loginStatus;
                    var loginUserSessionModel = new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName,
                    };
                    //登录成功后用户信息保存到回话
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    //identity 登录处理，登录令牌Token
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

        public ActionResult LoginOut()
        {
            //注销
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("index", "Home"); //返回首页
        }

        public ActionResult ChangePassWord()
        {

            //登录状态下用户才能修改密码
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login");
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassWord(ChangePassWordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //输入合法进行修改密码
                bool changePwdSuccessed;
                try
                {
                    var userManage =
                        new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                    var userName = (Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName;
                    //判断原密码是否输入正确
                    var user = userManage.Find(userName, model.PassWord);
                    if(user == null )
                    {
                        ModelState.AddModelError("", "原密码不正确！！！");
                        return View(model);
                    }
                    else
                    {
                        //修改密码
                        changePwdSuccessed = userManage.ChangePassword(user.Id, model.PassWord, model.NewPassWord).Succeeded;
                        if (changePwdSuccessed)
                            return Content("<script>alert('修改密码成功啦！'); location.href='" + Url.Action("login", "Account") + "'</script >");//修改密码成功后弹出对话框
                        else
                            ModelState.AddModelError("", "修改密码失败！请重试！");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "修改密码失败！请重试！");
                }
            }
            return View(model);
        }
    }
}