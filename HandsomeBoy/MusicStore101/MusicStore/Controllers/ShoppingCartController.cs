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
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();

        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //添加购物车；如果购物车中没有当前专辑，直接添加，数量为1；如果购物车中存在此专辑，数量+1
            //查询该用户的购物车记录是否包含此专辑

            var cartItm = _dbContext.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            var message = "";
            if (cartItm == null)
            {
                //该用户的购物车中没有此专辑
                cartItm = new Cart()
                {
                    AlbumID = id.ToString(),
                    Album = _dbContext.Albuns.Find(id),
                    Person = _dbContext.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_dbContext.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString(),
                };
                _dbContext.Carts.Add(cartItm);
                _dbContext.SaveChanges();
                message = "添加" + _dbContext.Albuns.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItm.Count++;
                _dbContext.SaveChanges();
                message = _dbContext.Albuns.Find(id).Title + "原来就在购物车里";
            }
            
            return View(message);
        }
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            //var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var list = context.Carts.OrderByDescending(x => x.CartDate).Take(24).ToList();

            return View(list);
        }
    }
}