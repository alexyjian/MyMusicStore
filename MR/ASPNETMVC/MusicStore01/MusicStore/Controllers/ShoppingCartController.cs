using MusicStore.ViewModels;
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
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            if(Session["LoginUserSessionModel"]==null)
            {
                return Json("nologin");
            }

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            
            var cartItem=_context.Carts.SingleOrDefault()
            return View();
        }
    }
}