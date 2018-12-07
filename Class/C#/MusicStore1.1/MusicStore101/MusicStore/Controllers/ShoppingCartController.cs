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


        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            return View(carts);
        }

        public ActionResult RemoveCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var cart = _Context.Carts.Where(x=>x.Person.ID == person.ID && x.ID == id);
            if (cart != null)
            {
                
            }
            return View();
        }
    }
}