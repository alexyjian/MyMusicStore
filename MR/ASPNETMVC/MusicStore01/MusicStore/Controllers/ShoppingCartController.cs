using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewModels;
using MusicStoreEntity;

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
            Thread.Sleep(1000);   //为了模仿真实网站环境，延时3秒，显示加载的艰苦 
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
                    AlbumID =  id.ToString(),
                    Album =  _context.Albums.Find(id),
                    Person = _context.Persons.Find(person.ID),
                    Count = 1,
                    CartID = (_context.Carts.Where(x=>x.Person.ID==person.ID).ToList().Count()+1).ToString()
                };
                _context.Carts.Add(cartItem);
                _context.SaveChanges();
                message = "添加" + _context.Albums.Find(id).Title + "到购物车成功！";
            }
            else
            {
                cartItem.Count++;
                _context.SaveChanges();
                message =  _context.Albums.Find(id).Title + "原来就在购物车中，已为您数量+1！";
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
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("index", "ShoppingCart")});

            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出该用户的购物车项
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();  //linq表达式 一句完成
            //decimal? totalPrice2 = 0.00M;
            //if (carts.Count == 0)
            //    totalPrice2 = null;
            //foreach (var item in carts)
            //{
            //    totalPrice2 += item.Count * item.Album.Price;
            //}

            //创建视图模型
            var cartVM = new ShoppingCartViewModel()
            {
                CartItems = carts,
                CartTotalPrice = totalPrice??decimal.Zero
            };

            return View(cartVM);
        }

        /// <summary>
        /// 删除购物车项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveCart(Guid id)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //查询出要处理删除的购物车项
            var cartItem = _context.Carts.Find(id);
            //如果购物项数量大于1则减1，如果为1则删除
            if (cartItem.Count > 1)
                cartItem.Count--;
            else
                _context.Carts.Remove(cartItem);
            _context.SaveChanges();

            //刷新局部视图  生成html元素注入到<tbody>中
            var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();
            var htmlString = "";
            foreach (var item in carts)
            {
                htmlString += "<tr>";
                htmlString += " <td><a href='../store/detail/"+item.ID+"'>"+item.Album.Title+"</a></td>";
                htmlString += "<td>"+item.Album.Price.ToString("C")+"</td>";
                htmlString += "<td>"+item.Count+"</td>";
                htmlString += "<td><a href=\"#\" onclick=\"removeCart('"+item.ID+"');\"><i class=\"glyphicon glyphicon-remove\"></i>移出购物车</a></td><tr>";
            }

            htmlString += "<tr><td></td><td></td><td>总价</td><td>"+totalPrice.ToString("C")+"</td></tr>";

            return Json(htmlString);
        }
    }
}