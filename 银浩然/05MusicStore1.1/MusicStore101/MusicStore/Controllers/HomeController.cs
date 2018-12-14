using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using System.Text;
using System.Collections.Specialized;
using System.Net;
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

        /// <summary>
        /// 测试登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string TestLogin(string username ="hs",string pwd = "123.abc")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + " ";
                return "登录成功，用户属于:"+ roleName;
            }
            else
                return "登录失败";
        }

        public ActionResult TestHack()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> TestHackAsync()
        {
            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("UserName", "admin"));
                values.Add(new KeyValuePair<string, string>("PassWord ", "123.abc"));
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://srs.lzzy.net/account/login", content);
                var responseString = await response.Content.ReadAsStringAsync();
                return Redirect("http://srs.lzzy.net/");
            }
        }
    }
}