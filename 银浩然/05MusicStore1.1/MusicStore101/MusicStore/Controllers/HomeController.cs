using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new MusicContext();
            var list= context.Ablums.OrderByDescending(x => x.PublisherDate).Take(20).ToList();
            return View(list);
        }
        /// <summary>
        /// 登录测试
        /// </summary>
        /// <returns></returns>
        public string TestLogin(string username = "xn", string pwd = "123.abc")
        {
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.MusicContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.MusicContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";
                return "登录成功，用户属于：" + roleName;
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
            //初始化提交的参数
            var values=new List<KeyValuePair<string,string>>();
            values.Add(new KeyValuePair<string, string>("UserName","admin"));
            values.Add(new KeyValuePair<string, string>("PassWorld","123.abc"));
            var content=new FormUrlEncodedContent(values);
            var respnse = await client.PostAsync("http://10.88.91.101:9000/account/login", content);
            //读出所有的结果
            var html = await respnse.Content.ReadAsStringAsync();
            return Json("");
        }
    }
}