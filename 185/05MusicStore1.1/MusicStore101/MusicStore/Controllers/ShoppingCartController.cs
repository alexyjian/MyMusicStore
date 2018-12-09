using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();

        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person =(Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartItem = _context.Cart.SingleOrDefault(x => x.Person.ID == person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                //该用户的购物车中没有此专辑
                cartItem = new Cart()
                {
                    AlbumID = id.ToString(),
                    Album = _context.Album.Find(id),
                    Person = _context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_context.Cart.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString()
                };
                _context.Cart.Add(cartItem);
                _context.SaveChanges();
                message = "添加" + _context.Album.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message = _context.Album.Find(id).Title + "原来就在购物车中，已为您数量+1！";
            }
            return Json(message);
        }
        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });
            

            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出该用户的购物车项
            var carts = _context.Cart.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();  //linq表达式 一句完成
            //decimal? totalPrice2 = 0.00M;
            //if (carts.Count == 0)
            //    totalPrice2 = null;
            //foreach (var item in carts)
            //{
            //    totalPrice2 += item.Count * item.Album.Price;
            //}

            //创建视图模型
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalPrice ?? decimal.Zero
            };

            return View(cartVM);
        }
        public ActionResult RemoveCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出要处理删除的购物车项
            var cartItem = _context.Cart.Find(id);
            //如果购物项数量大于1则减1，如果为1则删除
            if (cartItem.Count > 1)
                cartItem.Count--;
            else
                _context.Cart.Remove(cartItem);
            _context.SaveChanges();


            var carts = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail/'" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>"+item.Count+"</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>移出购物车</a></td><tr>";
            }
            htmlString += "<tr><td></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td></tr>";
            return Json(htmlString);
        }
    }
}