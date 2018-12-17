using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    var context = new EntityDbContext();
            
        //    return View(context.Albums.OrderByDescending(x=>x.PublisherDate).Take(20).ToList());
        //}
        public ActionResult Index()
        {
            var context = new EntityDbContext();

            return View(context.Albums.OrderByDescending(x => x.PublisherDate).Take(20).ToList());
        }


        public string Testlogin(string username = "xianren", string pwd = "123.abc")
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
            var user = userManager.Find(username,pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.EntityDbContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";
                return "登录成功," + roleName;
            }
            else
                return "登录失败";
        }
        public ActionResult TestHack()
        {
            return View();
        }
       
    }
}