using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ShoppingController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>
        // GET: Shopping
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {

            Thread.Sleep(3000);//为了模仿真实网站环境。延时3秒，显示加载的艰辛
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");


            var person = (Session["LoginUserSessionModel"]as LoginUserSeesionModel).Person;
            //添加购物车：如果购物车中没有当前专辑。直接添加。数量为1；如果购物车存在此专辑，数量+1
            //查询该用户的购物车记录是否包含此专辑
            var cartItem=_context.Carts.SingleOrfault(X=>X.Person.ID==X.Person.ID && X.Album.ID==id)
                var message = "";
            if (cartItem == null) ;
            {
                //该用户的购物车中没有此专辑
                cartItem =new 
            }

            return View();

        }
    }
}