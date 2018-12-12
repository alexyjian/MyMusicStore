using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;
using MusicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{
    public class OrderController : Controller
    {

        public static readonly MusicContext _Context = new MusicContext();

        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            //1.确认登录是否登录，是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var carts = _Context.Carts.Where(x => x.Person.ID == x.Person.ID).ToList();
            //算购物车的总价  ling表达式
            decimal? totalPrice = (from item in carts select item.Count * item.Ablum.Price).Sum();


            //3.创建新Order对象
            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _Context.Persons.Find(person.ID),
                TotalPrice = totalPrice ?? 0.00M,
            };

            //4.把购物项导入订单明细
            order.OrderDetails=new List<OrderDetail>();
            foreach (var item in carts)
            {
                var detail = new OrderDetail()
                {
                    AlbumID = item.AblumID,
                    Ablum = _Context.Ablums.Find(item.Ablum.ID),
                    Count = item.Count,
                    Price = item.Ablum.Price
                };
                order.OrderDetails.Add(detail);
            }
            //5.将订单和明细在视图呈现，验证用户收件人、地址、电话，供用户选择确认要购买的专辑
            //当前订单未持久化，用会话保存方便用户进行编辑
            Session["Order"] = order;
            return View(order);
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空，则重新刷新页面
            if (Session["Order"] == null)
                return RedirectToAction("Buy");

            //读取会话中的 Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrderDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表中移除明细记录
            order.OrderDetails.Remove(deleteDetail);

            //根据新的order对象重新生成html脚本，返回json数据，局部刷新视图
            var  htmlString = "";
            //订单总价
            var totalPrice = (from item in order.OrderDetails select item.Count * item.Ablum.Price).Sum();
            foreach (var item in order.OrderDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='"+Url.Action("Detail","Store",new {id=item.Ablum.ID})+"'>"+item.Ablum.Title+"</a></td>";
                htmlString += "<td>" + item.Ablum.Price.ToString("C") + "</td>";
                htmlString += "<td>" + item.Count + "</td>";
                htmlString += "<td><a href='#'onclick='RemoveDetail('"+item.ID+ "');'><i class='glyphicon glyphicon-remove'></i>我不喜欢它</a></td>";
                htmlString += "</tr>";
            }
            htmlString += "<tr><td></td><td></td><td>总价</td><td>" + order.TotalPrice.ToString("C") + "</td></tr>";
            return Json(htmlString);
        }

        /// <summary>
        /// 处理用户提交订单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            return View();
        }

        /// <summary>
        ///   浏览用户订单                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}