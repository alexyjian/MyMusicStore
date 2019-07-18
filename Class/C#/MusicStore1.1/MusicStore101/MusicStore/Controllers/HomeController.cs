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
            return View(context.Albums.OrderByDescending(x => x.PublisherDate).Take(20).ToList());
        }

        public ActionResult Store()
        {
            var context = new EntityDbContext();
            return View(context.Genres.ToList());
        }

        public string TestLogin(string username = "messi", string pwd = "123.abc")
        {
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = usermanager.Find(username, pwd);
            if (user == null)
            {
                return "登录失败！";
            }
            else
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                {
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).Name + " ";
                }
                return "登录成功！Name：" + roleName;
            }
        }

        public async Task<ActionResult> TestHack()
        {
            var client = new HttpClient();
            var values = new List<System.Collections.Generic.KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("UserName", "admin"));
            values.Add(new KeyValuePair<string, string>("PassWord", "123.abc"));
            var content = new FormUrlEncodedContent(values);
            var respnse = await client.PostAsync("http://10.88.91.101:9000/account/login", content);
            var html = await respnse.Content.ReadAsStringAsync();
            return Redirect("http://10.88.91.101:9000");
        }
    }
}