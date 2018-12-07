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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            //防止提交过快，提高用户体验
            Thread.Sleep(3000);

            //Ajax局部刷新
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            return View();
        }
    }
}