using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public ActionResult AddCart(Guid id)
        {
            //为了模仿真实网站环境，延时2秒，显示加载的艰苦
            Thread.Sleep(2000);

            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //添加到购物车：如果购物车中没有当前专辑，直接添加，数量为1;如果购物车中存在此专辑,数量+1
            //查询该用户的购物车记录是否包含此专辑
            var cartItem = _Context.Carts.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Ablum.ID == id);
            var message = "";
            if (cartItem == null)
            {
                //该用户的购物车里没有此专辑
                cartItem = new Cart()
                {
                    AblumID = id.ToString(),
                    Ablum = _Context.Ablums.Find(id),
                    Person = _Context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_Context.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString(),

                };
                _Context.Carts.Add(cartItem);
                _Context.SaveChanges();
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

        /// <summary>
        /// 查看用户自己的购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("Index", "ShoppingCart")});

            //查询出当前登录的用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出该用户的购物车项
            var carts = _Context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();

            //算购物车的总价  ling表达式
            decimal? totalPrice = (from item in carts select item.Count * item.Ablum.Price).Sum();


            //循环语句的写法
            //decimal? totalPrice1 = 0.00M;
            //if (carts.Count == 0)

            //    totalPrice1 = null;

            //foreach (var item in carts)
            //{
            //    totalPrice1 += item.Count * item.Ablum.Price;
            //}

            //创建视图模型
            var cartVM = new ShoppingCartVIewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalPrice ?? decimal.Zero
            };
            return View(cartVM);
        }

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出要处理删除的购物车项
            var cartItem = _Context.Carts.Find(id);

            //如果购物项数量大于1则减1，如果为1则删除
            if (cartItem.Count > 1)
                cartItem.Count--;
            else
                _Context.Carts.Remove(cartItem);
            _Context.SaveChanges();

            //刷新局部视图 生成html元素注入到<tbody>中
            var carts = _Context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Ablum.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail/" + item.ID + "'>" + item.Ablum.Title + "</a></td>";
                htmlString += "<td>" + item.Ablum.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>我不喜欢它了！</a></td>";

            }

            htmlString += "<tr><td></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td></tr>";

            return Json(htmlString);
        }


    }
}