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
    /// <summary>
    /// 查询用户自己的购物车
    /// </summary>
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
        public ActionResult Index()
        {

            //判断用户是否登录
            if (Session["loginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart")});

            //查询出当前的登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出该用户的购物车项
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();

            //计算购物车的总价
            //linq 表达式
            decimal? totalPrice = (from item in carts select item.Count* item.Album.Price).Sum();
            //创建视图模型
            //判断是否为空 为空则是它本身，则是所传的值
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotaPrice = totalPrice ?? decimal.Zero
            };
            return View(cartVM);
        }
        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name = "id" ></ param >
        /// < returns ></ returns >
        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            //判断用户是否登录
            if (Session["loginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出要处理删除的购物车项
            var cartItem = _context.Carts.Find(id);
            if (cartItem.Count > 1)
                cartItem.Count--;
            else
                _context.Carts.Remove(cartItem);
            _context.SaveChanges();

            //刷新局部视图  生成HTML的元素注入到表格<tbbody>
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += " <td>" + item.Count + "</td>";
                htmlString += " <td>< a href =\"#\"onclick =\"removeCart('" + item.ID + " ');\">< i class=\"glyphicon glyphicon-remove\"></i>移除购物车</a></td></tr>";
            }
            htmlString += "<tr>< td ></ td > < td ></ td >< td > 总计 </ td >< td >" + totalPrice.ToString("C") + "</ td ></ tr >";
            return Json("htmlString");

        }
    }

}