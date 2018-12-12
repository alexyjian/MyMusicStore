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
        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>
        // GET: ShoppingCart
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {

            //Thread.Sleep(3000);//延迟3S启用
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //添加购物车：如果购物车中没有当前专辑，直接添加，数量为1；如果购物车中存在此专辑，数量+1

            //查询该用户的购物车记录是否包含此专辑
            var cartItem = _context.Cart.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                //该用户的购物车中没有此专辑
                cartItem = new Cart()
                {
                    AlbumID = id.ToString(),
                    Album = _context.Albums.Find(id),
                    Person = _context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_context.Cart.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString(),
                };

                _context.Cart.Add(cartItem);
                _context.SaveChanges();
                message = "添加" + _context.Albums.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message = _context.Albums.Find(id).Title + "原来就在购物车当中 已为您数量+1";
            }
            return Json(message);
        }
        /// <summary>
        /// 查看用户自己的购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult ShoppingCart()
        {
            //判断用户是否登录如果没有跳转登录，登录成功后跳转回来
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("ShoppingCart", "ShoppingCart") });
            //查出出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询出该用户的购物车项
            var carts = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();//linq表达式一句完成

            //创建视图模型
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalPrice ?? decimal.Zero
            };
            return View(cartVM);
        }
        [HttpPost]
        public ActionResult RemoveCart(Guid id, int count)
        {
            //判断用户是否登录如果没有跳转登录，登录成功后跳转回来
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("ShoppingCart", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //要处理要查询出来的购物车项
            var cartItem = _context.Cart.Find(id);


            //数量-1
            if (count == 0)
            {
                if (cartItem.Count == 1)
                {
                    cartItem.Count = 1;
                }
                else
                {
                    cartItem.Count--;
                }

            }
            //数量+1
            if (count == 1)
            {
                if (cartItem.Count > 99)
                {
                    cartItem.Count = 99;
                }
                cartItem.Count++;
            }
            if (count == 2)
            {
                _context.Cart.Remove(cartItem);//删除
            }
            _context.SaveChanges();

            //刷新局部视图 生成html元素注入到<tbody>中
            var carts = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();
            //算购物车的总价
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td> <i class=\"glyphicon glyphicon-minus s \" onclick=\"minus('" + item.ID + "');\"></i>&nbsp;" + item.Count + "&nbsp;<i class=\"glyphicon glyphicon-plus s \" onclick=\"plus('" + item.ID + "')\"></i></td> ";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"> <i class=\"glyphicon glyphicon-remove\" ></i>我不喜欢这个了 抛弃！</a></td></tr>";
            }
            htmlString += "<tr><td colspan=\"4\" style=\"text-align:right\">总价格： <span style =\"color:red\">" + totalPrice.ToString("C") + "<span/></td></tr>";
            return Json(htmlString);
        }
    }
}