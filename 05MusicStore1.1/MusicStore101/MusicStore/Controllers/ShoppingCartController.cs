using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.Mvc;
using System.Linq;

namespace MusicStore.Controllers
{
    public class ShoppingCartController
    {
        ///<summary>
        ///添加专辑到购物车
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            Thread.Sleep(300); //

            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionMode).Person;
            //
            //
            var cartItem = _context.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                //
                cartItem = new Cart;
            }

            return View();
        }
    }
}