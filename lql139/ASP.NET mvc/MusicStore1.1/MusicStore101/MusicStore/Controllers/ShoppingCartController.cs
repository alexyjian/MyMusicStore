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
    public class ShoppingCartController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: ShoppingCart
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            Thread.Sleep(1000);
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var cartItem = _context.Cart.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    AlbumID = id.ToString(),
                    Album = _context.Albums.Find(id),
                    Person = _context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_context.Cart.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString()
                };
                _context.Cart.Add(cartItem);
                _context.SaveChanges();
                message = _context.Albums.Find(id).Title + "添加到购物车成功";
            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message = _context.Albums.Find(id).Title + "购物车已有同类商品，为你数量进行+1";
            }
            return Json(message);
        }

        public ActionResult index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
                var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
                var carts = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();
            //购物车总价
               decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            //decimal?totalPrice2= 0.00M;
            //if (carts.Count == 0)
            //    totalPrice2 = null;
            //foreach (var item in carts)
            //{
            //    totalPrice2 += item.Count * item.Album.Price;
            //}
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems=carts,
                CartTotalPrice=totalPrice??decimal.Zero
            };
            return View(cartVM);
        }

        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var cartItem = _context.Cart.Find(id);//要删除的项

            if (cartItem.Count > 1)//数量大于1减1，为1就删除
                cartItem.Count--;
            else
                _context.Cart.Remove(cartItem);
            _context.SaveChanges();

            //刷新局部视图
            var carts = _context.Cart.Where(x => x.Person.ID == x.Person.ID).ToList();
            var  totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr><th class=\"Cart-tbody-th\"><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></th>";
                htmlString += "<th>" + item.Album.Price.ToString("C") + "</th>";
                htmlString += "<th><button class=\"btn btn-default\" onclick=\"removeCartAdd('"+item.ID+"')\">+</button>&nbsp;" + item.Count + "&nbsp;<button class=\"btn btn-default\" onclick=\"removeCartSubtract('" + item.ID + "')\">-</button></th>";
                htmlString += "<th class=\"Cart-tbody-th\"><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>删除</a></th><tr>";
            }
            htmlString += "<tr><th ></th><th></th><th></th><th  class=\"totalprice - th\" colspan=\"4\">总价" + totalPrice.ToString("C") + "</th ></tr>";
            return Json(htmlString);
        }
        public ActionResult removeCartAdd(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartItem = _context.Cart.Find(id);
            if (cartItem.Count < 100)
                cartItem.Count++;
            else
                return Content("<script>alert('你的购买数量不能大于100');</script>");
            _context.SaveChanges();

            //刷新局部视图
            var carts = _context.Cart.Where(x => x.Person.ID == x.Person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr><th class=\"Cart-tbody-th\"><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></th>";
                htmlString += "<th>" + item.Album.Price.ToString("C") + "</th>";
                htmlString += "<th><button class=\"btn btn-default\" onclick=\"removeCartAdd('" + item.ID + "')\">+</button>&nbsp;" + item.Count + "&nbsp;<button class=\"btn btn-default\" onclick=\"removeCartSubtract('" + item.ID + "')\">-</button></th>";
                htmlString += "<th class=\"Cart-tbody-th\"><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>删除</a></th><tr>";

            }
            htmlString += "<tr><th ></th><th></th><th></th><th  class=\"totalprice - th\" colspan=\"4\">总价" + totalPrice.ToString("C") + "</th ></tr>";
            return Json(htmlString);
        }
        public ActionResult removeCartSubtract(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartItem = _context.Cart.Find(id);
            if (cartItem.Count > 1)
                cartItem.Count--;
            else
                return Content("<script>alert('你的购买数量不能小于0');</script>");
            _context.SaveChanges();

            //刷新局部视图
            var carts = _context.Cart.Where(x => x.Person.ID == x.Person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr><th class=\"Cart-tbody-th\"><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></th>";
                htmlString += "<th>" + item.Album.Price.ToString("C") + "</th>";
                htmlString += "<th><button class=\"btn btn-default\" onclick=\"removeCartAdd('" + item.ID + "')\">+</button>&nbsp;" + item.Count + "&nbsp;<button class=\"btn btn-default\" onclick=\"removeCartSubtract('" + item.ID + "')\">-</button></th>";
                htmlString += "<th class=\"Cart-tbody-th\"><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>删除</a></th><tr>";

            }
            htmlString += "<tr><th ></th><th></th><th></th><th  class=\"totalprice - th\" colspan=\"4\">总价" + totalPrice.ToString("C") + "</th ></tr>";
            return Json(htmlString);
        }
    }
}