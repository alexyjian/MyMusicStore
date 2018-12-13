using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            var cartItem = _context.OrdelDetail.Find(id);
            _context.OrdelDetail.Remove(cartItem);
            return Json("");
            //如果会话为空，则重新刷新页面
            if (Session["Order"] == null)
                return RedirectToAction("buy");
            //读取会话中的Order对象
            var order = Session["Order"] as Order;
            var deleteDetail = order.OrdelDetails.SingleOrDefault(x => x.ID == id);
            //从订单明细列表中移除明细记录
            order.OrdelDetails.Remove(deleteDetail);

            //更新用户编辑的会话
            Session["Order"] = order;
            var totalPrice = (from item in order.OrdelDetails select item.Count * item.Album.Price).Sum();

            //重新生成Html脚本，返回json数据，局部刷新视图
            var htmlString = "";
            foreach (var item in order.OrdelDetails)
            {
                htmlString += "<tr>";
                htmlString += "<td><a href='../store/detail/" + item.ID + "'>" + item.Album.Title + "</a></td>";
                htmlString += "<td> " + item.Count + "</td> ";
                htmlString += "<td>" + item.Album.Price.ToString("C") + "</td>";
                htmlString += "<td><a href=\"#\" onclick=\"RemoveDetail('" + item.ID + "');\"> <i class=\"glyphicon glyphicon-remove\" ></i>我不喜欢这个了 抛弃！</a></td></tr>";
            }
            htmlString += "<tr><td colspan=\"4\" style=\"text-align:right\">总价格： <span style =\"color:red\" >" + totalPrice.ToString("C") + "<span/></td></tr>";
            return Json(htmlString);
        }
        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Order(Order oder)
        public ActionResult Buy(Order oder)
        {
            return View();
        }
            //确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Order", "Order") });
            //读出当前用户Person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //从会话中读出订单明细列表
            var order = Session["Order"] as Order;
            //如果表单验证通过，则保存order到数据库（锁定进程），跳转到Pay/AliPay
            var item = new Order
         {

        Person = person,
        MobiNumber = oder.MobiNumber,
        OrdelDetails = order.OrdelDetails,
        Address = oder.Address,
        AddressPerson = oder.AddressPerson,
        TotalPrice = order.TotalPrice,
        PaySuccess = false,
    };

    _context.Order.Add(item);
            
            _context.SaveChanges();
            //如果验证不通过，返回视图
                 return View();
}
         /// <summary>
        /// 游览用户订单
        /// </summary>
    }
}