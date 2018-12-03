using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            var list = context.Albums.OrderByDescending(x => x.PublisherDate).Take(20).ToList();
            return View(list);
        }

        ///<summary>
        ///测试登录
        ///</summary>
        public string TestLogin(string username = "hs", string pwd = "123.abc")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + " ";
                return "登录成功，用户属于:" + roleName;
            }
            else
                return "登录失败";
        }

        ///<summary>
        ///伪造攻击
        /// </summary>
        /// <remarks></remarks>
        public ActionResult TestHack()
        {
            return View();
        }

        /// <summary>
        /// C#进行跨站伪造攻击
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> TesthackC()
        {
            var client = new HttpClient();
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("UserName", "admin"));
            values.Add(new KeyValuePair<string, string>("PassWord", "123.abc"));
            var content = new FormUrlEncodedContent(values);
            var respanse = await client.PostAsync("http://10.88.91.101:9000/account/login", content);
            var html = await respanse.Content.ReadAsStringAsync();
            return Json("");
        }
    }
}