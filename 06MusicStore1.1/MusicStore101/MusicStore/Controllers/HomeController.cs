using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using System.Threading.Tasks;
using System.Net.Http;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            var list = context.Albums.OrderByDescending(x => x.PublisherDate).Take(20).ToList();
            return View(list);
        }

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 测试登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string TestLogin(string username="wuzun",string pwd = "123.abc")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";
                return "登录成功,用户属于:" + roleName;
            }
            else
                return "登录失败";
        }

        /// <summary>
        /// 伪造攻击
        /// </summary>
        /// <returns></returns>
        public ActionResult TestHack()
        {
            return View();
        }
        /// <summary>
        /// 用C#进行跨站伪造攻击
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> TesthackC()
        {
            var client = new HttpClient();
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("UserName", "admin"));
            values.Add(new KeyValuePair<string, string>("PassWord", "123456"));
            var content = new FormUrlEncodedContent(values);
            var respnse=await client.PostAsync("http://localhost:2210/account/login", content);
            var html = await respnse.Content.ReadAsStringAsync();
            return Json("");
        }
    }
}