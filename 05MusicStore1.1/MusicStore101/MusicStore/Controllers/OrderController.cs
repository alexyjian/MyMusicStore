using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewModels;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class OrderController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();

        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            //1.确认用户是否登录  是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.查询出当前用户Person  查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车的总价
            decimal? totalPrice = (from item in carts select item.Count * item.Album.Price).Sum();  //linq表达式 一句完成

            //3.创建新Order对象
            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),
                TotalPrice = totalPrice??0.00M,
            };

            //4.把购物项导入订单明细
            order.OrderDetails = new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail = new OrderDetail()
                {
                    AlbumID = item.AlbumID,
                    Album = _context.Albums.Find(item.Album.ID),
                    Count = item.Count,
                    Price = item.Album.Price
                };
                order.OrderDetails.Add(detail);
            }

            //将订单和明细在视图呈现, 验证用户收件人、地址、电话，供用户选择确认要购买专辑

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
            //从订单明细列表中移除明细记录
            order.OrderDetails.Remove(deleteDetail);

            //根据新的order对象重新生成Html脚本，返回json数据，局部刷新视图
            var htmlString = "";
            //订单总价
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();
            //更新用户编辑到会话
            Session["Order"] = order;
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='"+Url.Action("Detail","Store",new {id=item.Album.ID})+"'>"
                    +item.Album.Title+"</a></td>";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td>"+item.Count+"</td>";
                htmlString += "<td><a href='#' onclick='RemoveDetail('"+item.ID+"');'><i class='glyphicon glyphicon-remove'></i>我不喜欢它了</a></td>";
                htmlString += "</tr>";
            }

            htmlString += "<tr><td></td><td></td><td>总价</td><td>" + order.TotalPrice.ToString("C") + "</td></tr>";

            return Json(htmlString);
        }

        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order order)
        {
            //1.判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            order.Person = _context.Persons.Find(person.ID);

            //3.从会话中读出订单明细列表
            order.OrderDetails = new  List<OrderDetail>();
            var details = (Session["Order"] as Order).OrderDetails;
            foreach (var item in details)
            {
                item.Album = _context.Albums.Find(item.Album.ID);
                order.OrderDetails.Add(item);
            }
            order.TotalPrice = (from item in order.OrderDetails select item.Count * item.Album.Price).Sum();

            //4.如果表单验证通过，则保存order到数据库（锁定进程），跳转到Pay/AliPay  
            if (ModelState.IsValid)
            {
                //加锁
                LockedHelp.ThreadLocked(order.ID);
                try
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    //清空购物车
                    var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
                    foreach (var cart in carts)
                    {
                        _context.Carts.Remove(cart);
                    }
                    _context.SaveChanges();

                    //把订单中的收件人信息保存到person中
                    var p = _context.Persons.Find(person.ID);
                    p.MobileNumber = order.MobilNumber;
                    p.Address = order.Address;
                    p.Name = order.AddressPerson;
                    p.FirstName = p.Name.Substring(0, 1);
                    p.LastName = p.Name.Substring(1, p.Name.Length - 1);
                    _context.SaveChanges();
                }
                catch
                {
                }
                finally
                {
                    LockedHelp.ThreadUnLocked(order.ID);
                }

                //跳转到支付页Pay/AliPay 
                return RedirectToAction("Alipay", "Pay", new {id = order.ID});
            }

            //5.如果验证不通过，返回视图
            return View();
        }

        /// <summary>
        /// 浏览用户订单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Order") });

            //查询该用户的订单列表
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var orders = _context.Orders.Where(x => x.Person.ID == person.ID).ToList();

            return View(orders);
        }
    }
}