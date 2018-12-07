using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        public static readonly MusicContext _Context = new MusicContext();

        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCart(Guid id )
        {
            //为了模仿真实网站环境，延时3秒，显示加载的艰苦
            Thread.Sleep(3000);

            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //添加到够诶车：如果购物车中没有当前专辑，直接添加，数量为
            //查询该用户的购物车记录是否包含此专辑
            var cartItem = _Context.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Ablum.ID == id);
            var message = "";
            if (cartItem == null)
            {
                //该用户的购物车里没有此专辑
                cartItem = new Cart()
                {
                    AblumID = id.ToString(),
                    Ablum = _Context.Ablums.Find(person.ID),
                    Person = _Context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_Context.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString(),

                };
                _Context.Carts.Add(cartItem);
                _Context.SaveChanges()
                    ;
                message = "添加" + _Context.Ablums.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItem.Count++;
                _Context.SaveChanges();
                message = _Context.Ablums.Find(id).Title + "原来你就在购物车里，已为您数量+1";
            }

            return Json(message);
           
        }
    }
}