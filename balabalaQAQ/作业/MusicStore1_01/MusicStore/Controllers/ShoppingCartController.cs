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
        public ActionResult ShoppingCart()
        {
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var list = _context.Cart.Where(x => x.Person.ID == person.ID).ToList();
            return View(list);
        }
    }
}