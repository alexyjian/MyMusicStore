using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost]//处理提交
        public ActionResult AddCart(Guid id)
        {
            
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            return View();
        }
    }
}