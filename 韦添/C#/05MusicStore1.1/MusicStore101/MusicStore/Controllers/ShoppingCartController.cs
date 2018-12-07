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
        // GET: ShoppingCart
        /// <summary>
        /// 添加专辑到购物
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            Thread.Sleep(2000);//延时2秒，显示加载的假哭
            if (Session["LoginUserSeessionModel"] == null)
                return Json("nologin");
            return View();
        }
    }
}