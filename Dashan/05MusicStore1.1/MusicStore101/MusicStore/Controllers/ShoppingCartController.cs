using MusicStore.ViewMoldels;
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
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {

            Thread.Sleep(1000);//延迟1秒

            if (Session["loginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //添加购车 ： 如果购物车中没有当前专辑，直接添加，数量为1；如果购物车已存在此专辑，数量则+1
            //查询该用户的购物记录是否包含此专辑
            var cartItem = _context.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
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
                    CartID = (_context.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString(),

            };
            _context.Carts.Add(cartItem);
            _context.SaveChanges();
            message = "添加" + _context.Albums.Find(id).Title + "到购物车成功！";
           }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message = _context.Albums.Find(id).Title + "已为你再次数量+1";
            }
            return Json(message);
        }
    }
}