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
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var idManager = new IdentityManager();
                var person = new Person()
                {
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    Name = model.FullName,
                    CredentialsCode = "",
                    Birthday = DateTime.Now,
                    Sex = false,
                    MobileNumber = "13899998888",
                    Email = model.Email,
                    CreateDateTime = DateTime.Now,
                    TelephoneNumber = "80861688",
                    Description = "用户",
                    UpdateTime = DateTime.Now,
                    InquiryPassword = "未设置",
                };
                var newUser = new ApplicationUser()
                {
                    FirstName = model.FullName.Substring(0, 1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    UserName = model.UserName,
                    ChineseFullName = model.FullName,
                    MobileNumber = "13899998888",
                    Email = model.Email,
                    Person = person,
                };
                //是否要验证Email

                idManager.CreateUser(newUser, model.PassWord);
                idManager.AddUserToRole(newUser.Id, "RegisterUser");
                return Content("<script>alert('恭喜注册成功！');location.href='" + Url.Action("Account", "login") + "'+<script/>");
            }
            else { return View(); }
        }


        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="returnUrl">登录成功后跳转地址</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
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
                    IsLogin = false,
                    Message = "用户或密码错误",
                };
                //登录处理
                var userManage =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
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
        //修改密码
        public ActionResult RevisePwd()
        {
            if (Session["LoginUserSessionModel"] == null)
            { return RedirectToAction("Login"); }
            return View();
        }
        [HttpPost]
        public ActionResult RevisePwd(RevisePwdViewModelr model)
        {
            //用户先得登录才能修改

            if (ModelState.IsValid)
            {
                //输入合法，进行修改
                bool changePwdSuccessed;
                try
                {

                    var userManage =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
                    var userName = (Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName;
                    //判断原密码是否输入正确
                    var user = userManage.Find(userName, model.PassWord);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "原密码不正确");
                        return View(model);
                    }
                    else
                    {
                        //修改密码
                        changePwdSuccessed = userManage.ChangePassword(user.Id, model.PassWord, model.NewPassWord).Succeeded;
                        if (changePwdSuccessed)
                        {
                            return Content("<script>alert('恭喜修改密码成功!');location.href='" + Url.Action("index", "home") +
                                           "'</script>");
                        }
                        else
                        {
                            ModelState.AddModelError("", "修改密码失败，请重试");
                        }
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "修改密码失败，请重试");
                }
            }

            return View(model);
        }
        //个人信息
        public ActionResult userInfo()
        {
            return View();
        }
        /// <summary>
        /// 用户注销
        /// </summary>
        /// <returns></returns>
        public ActionResult loginout()
        {
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("index", "Home");
        }
    }
}