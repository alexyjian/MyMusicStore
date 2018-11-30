using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Login()
        {
            return View();
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
    }
}