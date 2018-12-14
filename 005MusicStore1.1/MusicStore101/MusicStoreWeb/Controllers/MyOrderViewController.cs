using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyOrderViewController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });

            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出该用户的购物车项
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算出购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum(); //linq表达式一句完成

            //创建视图模型
            var cartVM = new MyOrderViewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalPrice ?? decimal.Zero
            };

            return View();
        }
    }
}