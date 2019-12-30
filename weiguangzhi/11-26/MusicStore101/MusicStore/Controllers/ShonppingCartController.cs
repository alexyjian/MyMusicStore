using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class ShonppingCartController : Controller
    {

        private static readonly EntityDbContext _context = new EntityDbContext();

        /// <summary>
        /// 添加专辑到购物车
        /// </summary>
        /// <returns></returns>
        // GET: ShonppingCart
        [HttpPost]
        public ActionResult AddCart(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //添加购物车：如果购物车中没有当前专辑，直接添加，数量为1；如果购物车中存在此专辑，数量+1
            //查询该用户的购物车记录是否包含此专辑
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
                    CartID = (_context.Carts.Where(x => x.Person.ID == person.ID).ToList().Count() + 1).ToString()
                };
                _context.Carts.Add(cartItem);
                _context.SaveChanges();
                message = "添加" + _context.Albums.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
               message = _context.Albums.Find(id).Title + "原来就在购物车中，已为您数量+1！";
            }
            return Json(message);
        }
        public ActionResult Jia(Guid id)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });
            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出要处理删除的购物车项
            var cartItrm = _context.Carts.Find(id);
            //如果购物项数量大于1则减1，如果为1则删除
            if (cartItrm.Count > 0)
                cartItrm.Count++;
            else
                _context.Carts.Add(cartItrm);
            _context.SaveChanges();

            //刷新局部视图 生成html元素注入到<tbody>中
            var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();//linq表达式一句完成
            var htmlString = "";
            foreach (Cart item in carts)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>移出购物车</a></td><tr>";
            }

            htmlString += "<tr><td ></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td ></tr>";

            return Json(htmlString);
        }

        public ActionResult Index()
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });

            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //查询出该用户的购物车项
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();

            //算购物车的总价
            decimal? totalRirce = (from item in carts select item.Count * item.Album.Price).Sum();//linq表达式一句完成

            //    var detail = _context.Carts.Find(id);
            //return View(detail);

            //创建视图模型
            var cartVm = new ShonppingCartViewModel()
            {
                CartItems=carts,
                CartTotalPrice= totalRirce??decimal.Zero
            };
            return View(cartVm);
        }
        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });
            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出要处理删除的购物车项
            var cartItrm = _context.Carts.Find(id);
            //如果购物项数量大于1则减1，如果为1则删除
            if (cartItrm.Count > 1)
                cartItrm.Count--;
            else
                _context.Carts.Remove(cartItrm);
            _context.SaveChanges();

            //刷新局部视图 生成html元素注入到<tbody>中
            var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice= (from item in carts select item.Count * item.Album.Price).Sum();//linq表达式一句完成
            var htmlString = "";
            foreach (Cart item in carts)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('" + item.ID + "');\"><i class=\"glyphicon glyphicon-remove\"></i>移出购物车</a></td><tr>";
            }

            htmlString += "<tr><td ></td><td></td><td>总价</td><td>" + totalPrice.ToString("C") + "</td ></tr>";

            return Json(htmlString);
        }
    }
}