using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class LoginController : Controller
    {
       
        /// <summary>
        /// 填写注册信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Register() {
            //if (string.IsNullOrEmpty(returnUrl))

            //    ViewBag.ReturnUrl = Url.Action("index", "home");
            //else
            //    ViewBag.ReturnUrl = returnUrl;

            return View();
        }
        [HttpPost] //此Action用来接收用户提交
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {

            //用户
            if (ModelState.IsValid)
            {
                var idManger = new IdentityManager();
                #region 管理员
                var person1 = new Person()
                {
                    FirstName = model.FullName.Substring(0,1),
                    LastName = model.FullName.Substring(1, model.FullName.Length - 1),
                    Name = model.UserName,
                    CredentialsCode = "4500002015010112345",
                    Birthday = DateTime.Parse("2015-01-01"),
                    Sex = true,
                    MobileNumber = "13833883388",
                    Email = model.Email,
                    CreateDateTime = DateTime.Now,
                    TelephoneNumber = "3158899",
                    Description = "超级管理员",
                    UpdateTime = DateTime.Now,
                    InquiryPassword = "123456",
                };
                var loginUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    FirstName = model.FullName,
                    LastName = "西",
                    ChineseFullName = "梅西",
                    MobileNumber = "13833883388",
                    Email = "messi@163.com",
                    Person = person1,
                };
                //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
                idManger.CreateUser(loginUser, model.PassWord);
                //添加到Admin角色
                idManger.AddUserToRole(loginUser.Id, "Admin");
                return Content("<script>alert('恭喜注册成功!');location.href='" + Url.Action("login", "Login") + "'</script>");
                #endregion
            }
            return View();
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
        [HttpPost] //此Action用来接收用户提交
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //判断实体是否校验通过
            if (ModelState.IsValid)
            {
                var loginStaus = new LoginUserStatus()
                {
                    IsLogin = false,
                    Message = "用户或密码错误"
                };

                //登录处理
                var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
                var user = userManage.Find(model.UserName, model.PassWord);
                if (user != null)
                {
                    var roleName = "";
                    var context = new MusicStoreEntity.EntityDbContext();
                    foreach (var role in user.Roles)
                    {
                        roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";
                    }
                    loginStaus.IsLogin = true;
                    loginStaus.Message = "登录成功！用户名的角色: "+roleName;
                    loginStaus.GotoController = "home";
                    loginStaus.GotoAction = "index";
                    //把登录状态保存到会话
                    Session["loginStaus"] = loginStaus;
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
                    ViewBag.LoginUserStatus = loginStaus;
                    return View();
                }
            }
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("index", "home");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult TestHack() {
            return View();
        }

        public async Task<ActionResult> TesthackC()
        {
            var chent = new HttpClient();
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("UserName", "admin"));
            values.Add(new KeyValuePair<string, string>("PassWord", "123.abc"));
            var content = new FormUrlEncodedContent(values);
            var resonse = await chent.PostAsync("http://10.88.91.101:9000/account/login",content);
            var html = await resonse.Content.ReadAsStringAsync();
            return Json("");
        }
        // GET: Login
        /// <summary>
        /// 测试登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string TestLogin(string username = "messi", string pwd = "123.abc")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";
                return "登录成功,用户属于：" + roleName;
            }
            else
                return "登录失败";
        }

        //注销
        public ActionResult LoginOut()
        {
            Session.Remove("loginStatus");
            Session.Remove("LoginUserSessionModel");
            return RedirectToAction("index", "Home");
        }
        public ActionResult ChangePassWord()
        {
            //用户先得登录才能修改
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login");

            return View();
        }
        [HttpPost]
        public ActionResult ChangePassWord(ChangePassWordViewModel model)
        {
            //用户先得登录才能修改
            if (ModelState.IsValid)
            {
                //输入合法，进行修改密码
                bool changePwdSuccessed;
                try {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
                    var userName = (Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName;
                    var user = userManager.Find(userName, model.NewPassWord);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "原密码不正确");
                        return View();
                    }
                    else
                    {
                        //修改密码
                        changePwdSuccessed = userManager.ChangePassword(user.Id, model.NewPassWord, model.ConfirmPassWord).Succeeded;
                        if (changePwdSuccessed)
                            return Content("<script>alert('恭喜修改密码成功!');location.href='" + Url.Action("index", "home") +
                                        "'</script>");
                        else
                            ModelState.AddModelError("", "修改密码失败，请重试");
                    }
                }
                catch {
                    ModelState.AddModelError("", "修改密码失败，请重试");
                }
            }
            return View(model);
        }
    }
}