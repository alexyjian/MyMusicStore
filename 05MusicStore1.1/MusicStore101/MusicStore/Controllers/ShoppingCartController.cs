using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            Thread.Sleep(3000);   //为了模仿真实网站环境，延时3秒，显示加载的艰苦 

            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            return View();
        }
    }
}