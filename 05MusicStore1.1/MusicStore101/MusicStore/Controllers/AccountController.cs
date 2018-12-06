﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = new Person()
                {
                    FirstName = model.FullName.Substring(0,1),
                    LastName = model.FullName.Substring(1,model.FullName.Length-1),
                    Name =  model.FullName,
                    CredentialsCode ="",
                    Birthday = DateTime.Now,
                    Sex = true,
                    MobileNumber = "18866668888",
                    Email = model.Email,
                    TelephoneNumber = "18866668888",
                    Description = "",
                    CreateDateTime = DateTime.Now,
                    UpdateTime =  DateTime.Now,
                    InquiryPassword = "未设置",
                };
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    ChineseFullName = model.FullName,
                    MobileNumber = "18866668888",
                    Email = model.Email,
                    Person = person,
                };

                //是否要验证Email

                var idManager = new IdentityManager();
                idManager.CreateUser(user, model.PassWord);
                idManager.AddUserToRole(user.Id, "RegisterUser");

                return Content("<script>alert('恭喜注册成功!');location.href='"+Url.Action("login","Account")+"'</script>");
            }
            
            return View();
        }



        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="returnUrl">登录成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl=null)
        {
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]   //此Action用来接收用户提交
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //判断实体是否校验通过
            if (ModelState.IsValid)
            {
                var loginStatus = new LoginUserStatus()
                {
                     IsLogin =  false,
                    Message =  "用户或密码错误",
                };
                //登录处理
                var userManage =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                var user = userManage.Find(model.UserName, model.PassWord);
                if (user != null)
                {
                    var roleName = "";
                    var context = new EntityDbContext();
                    foreach (var  role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + ",";
                    }

                    loginStatus.IsLogin = true;
                    loginStatus.Message = "登录成功！用户的角色：" + roleName;
                    loginStatus.GotoController = "home";
                    loginStatus.GotoAction = "index";
                    //把登录状态保存到会话
                    Session["loginStatus"] = loginStatus;

                    var loginUserSessionModel = new LoginUserSessionModel()
                    {
                        User = user,
                        Person = user.Person,
                        RoleName = roleName,
                    };
                    //把登录成功后用户信息保存到会话
                    Session["LoginUserSessionModel"] = loginUserSessionModel;

                    //identity登录处理,创建aspnet的登录令牌Token
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