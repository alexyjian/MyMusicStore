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
        private static readonly EntityDbContext _Context = new EntityDbContext();
        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            //防止提交过快，提高用户体验
            Thread.Sleep(1500);

            //Ajax局部刷新
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            //登录成功的会话
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询是否有该专辑
            var cartItem = _Context.Carts.SingleOrDefault(x => x.Person.ID == person.ID && x.Album.ID == id);
            var message = "";
            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    AlbumID = id.ToString(),
                    Album = _Context.Albums.Find(id),
                    Person = _Context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_Context.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString()
                };
                _Context.Carts.Add(cartItem);
                _Context.SaveChanges();
                message = $"(已将 《{_Context.Albums.Find(id).Title}》 添加至购物车！)";
            }
            else
            {
                cartItem.Count++;
                _Context.SaveChanges();
                message = $"(已将 《{_Context.Albums.Find(id).Title}》 添加至购物车！)";
            }
            return Json(message);
        }

        /// <summary>
        /// 购物车视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalPrice ?? decimal.Zero
            };
            return View(cartVM);
        }

        /// <summary>
        ///  移除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询是否有某用户的某购物车单
            var cartItem = _Context.Carts.Find(id);
            _Context.Carts.Remove(cartItem);
            _Context.SaveChanges();

            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            decimal totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }

            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ totalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }

        /// <summary>
        /// 添加数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCount(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartItem = _Context.Carts.Find(id);
            cartItem.Count++;
            _Context.SaveChanges();

            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            decimal totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }

            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ totalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }

        /// <summary>
        /// 减少数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MinusCount(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cartItem = _Context.Carts.Find(id);
            if (cartItem.Count > 1)
                cartItem.Count--;
            _Context.SaveChanges();

            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            decimal totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();

            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += $"<tr><td><a href='../../Store/Detail/{item.Album.ID}'>{item.Album.Title}</a></td>";
                htmlString += $"<td>{ item.Album.Price.ToString("C")}</td>";
                htmlString += "<td><a href = '#' class='glyphicon glyphicon-minus' onclick=" + '"' + "minusCount('" + item.ID + "')" + '"' + "></a>&nbsp;" + item.Count + "&nbsp;<a href = '#' class='glyphicon glyphicon-plus' onclick=" + '"' + "addCount('" + item.ID + "')" + '"' + "></a></td>";
                htmlString += $"<td><a href = '#' class='text-danger' onclick=" + '"' + "Remove('" + item.ID + "')" + '"' + "><span class='glyphicon glyphicon-remove'></span> 我不喜欢这个了</a></td></tr>";
            }

            htmlString += $"<tr><td></td><td></td><td> 总价 </td><td>{ totalPrice.ToString("C")} </td></tr>";

            return Json(htmlString);
        }
    }
}