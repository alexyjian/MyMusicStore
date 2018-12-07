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
        // GET: ShoppingCart
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {

            //Thread.Sleep(3000);//延迟3S启用
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            return View();
        }
    }
}