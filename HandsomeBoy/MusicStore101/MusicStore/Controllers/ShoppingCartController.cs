using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

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
            var albun = _dbContext.Albuns.Single(x => x.ID == id);
            var message = "";
            if (cartItm == null)
            {
                //该用户的购物车中没有此专辑
                cartItm = new Cart()
                {
                    AlbumID = id.ToString(),
                    //Album = _dbContext.Albuns.Find(id),
                    Album = albun,
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
            
            return Json(message);
        }
        /// <summary>
        /// 查看用户自己的购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            //查询当前登录用户

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var list = _dbContext.Carts.Where(x => x.Person.ID== person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in list select item.Count * item.Album.Price).Sum();

            //创建视图模型
            var cartVM = new ShoppingCartViewModel()
            {
                CarItems = list,
                CartTotaIprice = totalPrice ?? decimal.Zero

            };
            return View(cartVM);
        }
        //我的写法
        //[HttpPost]
        //public ActionResult Delete(Guid id)
        //{

        //    if (Session["LoginUserSessionModel"] == null)
        //        return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });

        //    var cartItem = _dbContext.Carts.Find(id);

        //    if (cartItem.Count > 1)
        //    {
        //        cartItem.Count -= 1;            }
        //    else {
        //       _dbContext.Carts.Remove(cartItem);
        //    }
        //    _dbContext.SaveChanges();
        //    return Json("");
        //}


        //老师的写法

        //我的写法
        [HttpPost]
        public ActionResult Delete(Guid id)
        {

            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });

            var cartItem = _dbContext.Carts.Find(id);
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //if (cartItem.Count > 1)
            //{
            //    cartItem.Count -= 1;
            //}
            //else
            //{
                _dbContext.Carts.Remove(cartItem);
            //}
            _dbContext.SaveChanges();

            //刷新局部视图  生成html元素注入到<tbody>中
            var carts = _dbContext.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>";
                htmlString += "<ul class=\"count\">";
                htmlString += " <li><span id =\"num - jian\" class=\"num - jian\" onclick=\"jiajianCount('" + item.ID + "','jian')\">-</span></li>";
                htmlString += " <li><input type =\"text\" class=\"input-num\" id=\"input-num\" value=" + item.Count + " /></li>";
                htmlString += "<li><span id = \"num -jia\" class=\"num-jia\" onclick=\"jiajianCount('" + item.ID + "','jia')\">+</span></li>";
                htmlString += "</ul>";
                htmlString += "</td>";
                htmlString += "<td><a href=\"javascript:;\" onclick=\"Delete('" + item.ID + "')\"><i class=\"glyphicon glyphicon-remove\"></i>我不想要他了</a></td><tr>";
            }

            htmlString += "<tr><td ></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td ></tr>";
            return Json(htmlString);
        }
        [HttpPost]
        public ActionResult Modified(Guid id,string jj)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var carts = _dbContext.Carts.Where(x => x.Person.ID == person.ID).ToList();
          
               var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
        

            foreach (var item in carts)
            {
                if (item.ID == id)
                {
                    if (jj == "jia")
                    {
                        item.Count++;
                    }
                    else if (jj == "jian")
                    {
                        if (item.Count >= 2)
                            item.Count--;
                    }
                }
            }

            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>";
                htmlString += "<ul class=\"count\">";
                htmlString += " <li><span id =\"num - jian\" class=\"num - jian\" onclick=\"jiajianCount('" + item.ID + "','jian')\">-</span></li>";
                htmlString += " <li><input type =\"text\" class=\"input-num\" id=\"input-num\" value=" + item.Count + " /></li>";
                htmlString += "<li><span id = \"num -jia\" class=\"num-jia\" onclick=\"jiajianCount('" + item.ID + "','jia')\">+</span></li>";
                htmlString += "</ul>";
                htmlString += "</td>";
                htmlString += "<td><a href=\"javascript:;\" onclick=\"Delete('" + item.ID + "')\"><i class=\"glyphicon glyphicon-remove\"></i>我不想要他了</a></td><tr>";
            }

            htmlString += "<tr><td ></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td ></tr>";
            return Json(htmlString);
        }
    }

}