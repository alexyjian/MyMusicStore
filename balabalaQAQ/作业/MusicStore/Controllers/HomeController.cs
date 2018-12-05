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
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            
            return View(context.Albums.OrderByDescending(x=>x.PublisherDate).Take(20));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        /// <summary>
        /// 显示所有的分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Store()
        {
            var context = new EntityDbContext();

            return View(context.Genres.OrderBy(x=>x.Name).ToList());
        }
        /// <summary>
        ///  伪造攻击
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
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("UserName", "admin"));
            values.Add(new KeyValuePair<string, string>("PassWord", "123.abc"));
            var content = new FormUrlEncodedContent(values);
            var respnse = await client.PostAsync("http://10.88.91.101:9000/account/login", content);
            var html = await respnse.Content.ReadAsStringAsync();
            return Json("");
        }
    }

}