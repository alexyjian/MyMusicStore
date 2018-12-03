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

        public ActionResult Register() {
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
            }
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
    }
}