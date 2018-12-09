using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Music.ViewModels;
using MusicStoreEntity;

namespace Music.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: ShoppingCart
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            Thread.Sleep(1000);//为了模仿真实网站环境，延时3秒，显示加载的艰辛
            if (Session["loginUserSessionModel"] ==null)
            {
                return Json("nologin");
            }

            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            //添加购物车：如果购物车中没有当前专辑，直接添加，数量为1；如果购物车中存在此专辑，数量+1
            //查询该用户的购物车纪录是否含此专辑
            var cartItem = _context.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                //该用户的购物车中没有此专辑
                cartItem = new Cart()
                {
                    AlbumID =id.ToString(),
                    Album =_context.Albums.Find(id),
                    Person = _context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_context.Carts.Where(x=>x.Person.ID==person.ID).ToList().Count()+1).ToString()
                };
                _context.Carts.Add(cartItem);
                _context.SaveChanges();
                message = "添加" + _context.Albums.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message = _context.Albums.Find(id).Title + "原来就在购物车中，以为您数量+1";
            }

            return Json(message);
        }
        /// <summary>
        /// 查看用户自己的购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //判断用户是否登陆
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl=Url.Action("Index","ShoppingCart")});
            }
            //查询出当前登陆用户
            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询出当前该用户的购物车项
            var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum(); //Linq表达式
            //创建视图模型
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotaLPrice = totalPrice ?? decimal.Zero
            };
            return View(cartVM);
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (Session["loginUserSessionModel"] == null)
            {
                return Json("nologin");
            }
            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var caartItem = _context.Carts.SingleOrDefault(x=>x.ID==id);
            _context.Carts.Remove(caartItem);
            _context.SaveChanges();
            var message = "";
            return Json(message);
        }
    }
}