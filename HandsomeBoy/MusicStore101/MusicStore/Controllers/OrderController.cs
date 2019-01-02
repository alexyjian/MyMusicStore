using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class OrderController : Controller
    {
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        // GET: Order
        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            //1.确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //2.查询出当前用户Person 查询改用户的购物项
            var cartItm = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in cartItm select item.Count * item.Album.Price).Sum();
            //3.创建Order对象
            var order = new Order()
            {
                Person = _context.Persons.Find(person.ID),
                TotalPrice = totalPrice??0.00M,
            };
            //4.把购物项导入订单明细
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in cartItm) {
                var detail = new OrderDetail()
                {
                    AlbumID = item.AlbumID,
                    Album = _context.Albuns.Find(item.Album.ID),
                    Count = item.Count,
                    Price = item.Album.Price,
                    CartID = item.ID
                };
                order.OrderDetails.Add(detail);
            }
            //将订单和明细在视图呈现，验证用户收件人、地址、电话，供用户选择确认要购买的专辑

            //当前订单未持久化，用会话保存方便用户进行编辑
            Session["Order"] = order;
            return View(order);
        }
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空，则重新刷新页面
            if (Session["Order"] == null)
                return RedirectToAction("buy");
            //读取会话中的Order对象
            var order = Session["Order"] as Order;

            var deleteDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表移除明细记录
            order.OrderDetails.Remove(deleteDetail);
            //订单总价
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();
            //根据新的order对象重新生成html脚本，返回json数据，局部刷新视图
            var htmlString = "";
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a html='../store/detail/" + item.AlbumID + "'>" + item.Album.Title ;
                htmlString += "</td></a>";
                htmlString += "<td>" + item.Album.Price.ToString("C")+"</td>";
                htmlString += "<td><ul class=\"count\">";
                htmlString += "<li><span id = \"num-jian\" class=\"num - jian\" onclick=\"jiajianCount('" + item.ID+"','jian')\">-</span></li>";
                htmlString += "<li><input type =\"text\" class=\"input-num\" id=\"input-num\" value="+item.Count+"></li>";
                htmlString += " <li><span id = \"num - jia\" class=\"num - jia\" onclick=\"jiajianCount('" + item.ID+ "','jia')\">+</span></li>";
                htmlString += "</ul></td>";
                htmlString += "<td><a href=\"javascript:; \" id=\""+item.ID+ "\" onclick=\"RemoveDetail('"+item.ID+"')\"><i class=\"glyphicon glyphicon-remove\"></i>我不想要他了</a></td>";
                htmlString += "</tr>";
            }
            htmlString += "<tr>";
            htmlString += "<td></td><td></td><td> 总价 </td><td> " + order.TotalPrice.ToString("C") + " </ td >";
            htmlString += "</ tr >";
            return Json(htmlString);
        }
        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(string id,Order order)
        {
            if (id != null)
            {
                Session["ID"] = id;
                return Json("");
            }
                
        
            //1.判断登录是否过期，如果过期跳到登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            //2.读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            order.Person = _context.Persons.Find(person.ID);
            //3.从会话中读出订单明细列表
            order.OrderDetails = new List<OrderDetail>();

            //上传图片
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase f = Request.Files["file1"];
                f.SaveAs(@"D:\" + f.FileName);
            }


            string  ID = Session["ID"].ToString();

            var details = (Session["Order"] as Order).OrderDetails;
            foreach (var item in details)
            {
                item.Album = _context.Albuns.Find(item.Album.ID);
                order.OrderDetails.Add(item);
            }
            Guid guid =Guid.Parse(Session["ID"].ToString());
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();
             order.Mys =_context.Mys.Find(Guid.Parse(ID));
            //order.Mys = _context.Mys.Find(guid);
            //4.如果表单验证通过，则保存 order到数据库（锁定进程），跳转到Pay/Alipay
            if (ModelState.IsValid)
            {
                //加锁
                LockedHelp.ThreadLocked(order.ID);
                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    //移除购物车
                  
                    var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
                    foreach (var cart in carts)
                    {
                        _context.Carts.Remove(cart);
                    }
                }
                catch
                { }
                finally
                {
                    LockedHelp.ThreadUnLocked(order.ID);
                }
                //跳转到支付页
                return RedirectToAction("Alipay", "Pay", new { id = order.ID });
            }
            return View();
        }

        /// <summary>
        /// 浏览用户订单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var list = _context.Orders.Where(x => x.Person.ID== person.ID).ToList();

            return View(list);
        }
    }
}