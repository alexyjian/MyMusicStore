using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MusicStore.ViewModels;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class PayController : Controller
    {
        private readonly EntityDbContext _context = new EntityDbContext();

        #region 阿里支付

        /// <summary>
        /// 阿里支付
        /// </summary>
        /// <param name="id">订单ID</param>
        /// <param name="url">成功后跳转url</param>
        /// <returns></returns>
        public ActionResult AliPay(Guid id, string url = null)
        {
            if (string.IsNullOrEmpty(url))
                url = Url.Action("Index", "order", new { id = id });

            //查询订单数据
            var order = _context.Orders.Find(id);

            //如果订单为空，直接返回400错误
            if (order == null)
                return new HttpStatusCodeResult(400);

            //查询order状态，以免重复支付，重复支付
            if ((int)order.EnumOrderStatus > 0)
            {
                //已经支付成功，不能重复支付,跳转个人中心
                var returnUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/order/list";
                return Redirect(returnUrl);
            }

            //查询person
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account",
                    new { returnUrl = Url.Action("AliPay", "Pay", new { id = id, url = Url }) });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            if (order.Person.ID != person.ID)
            {
                //不是自己的订单
                return new HttpStatusCodeResult(400);
            }

            //测试 所有都支付0.01
            order.TotalPrice = 0.01M;
            _context.SaveChanges();

            ViewBag.ReturnUrl = url;
            ViewBag.PayPrice = order.TotalPrice;
            ViewBag.TradeNo = order.TradeNo;
            Session["AlipayOrderID"] = id;

            return View(order);
        }

        public async Task<ActionResult> NotifyAsync(string notify_id, string sign, Guid out_trade_no, string trade_no,
            decimal total_fee, string returnUrl = null)
        {
            if (AlipayHelper.VerifyParameter("q12vmic8884u68lgvgczye89ga4bizli", Request.Form) == false)
                return Content("fail");
            if (await AlipayHelper.VerifyNotify("2088021994748781", notify_id) == false)
                return Content("fail");

            var order = _context.Orders.Find(out_trade_no);
            if (order == null)
                return Content("fail");
            if (order.PaySuccess)
                return Redirect(returnUrl);

            //修改是否完成支付状态，获取支付成功后的订单后
            LockedHelp.ThreadLocked(order.ID);
            try
            {
                order.TradeNo = trade_no;
                order.PaySuccess = true;
                order.EnumOrderStatus = EnumOrderStatus.已付款;
                _context.SaveChanges();
            }
            finally
            {
                LockedHelp.ThreadUnLocked(order.ID);
            }

            return Redirect(returnUrl);
        }

        public async Task<ActionResult> ReturnAsync(string notify_id, string sign, Guid out_trade_no, string trade_no,
            decimal total_fee, string returnUrl = null)
        {
            if (AlipayHelper.VerifyParameter("q12vmic8884u68lgvgczye89ga4bizli", Request.QueryString) == false)
                return Content("fail");
            if (await AlipayHelper.VerifyNotify("2088021994748781", notify_id) == false)
                return Content("fail");

            var order = _context.Orders.Find(out_trade_no);

            if (order == null)
                return Content("fail");
            if (order.PaySuccess)
                return Redirect(returnUrl);

            //修改是否完成支付状态，获取支付成功后的订单后
            LockedHelp.ThreadLocked(order.ID);
            try
            {
                order.TradeNo = trade_no;
                order.PaySuccess = true;
                order.EnumOrderStatus = EnumOrderStatus.已付款;
                _context.SaveChanges();
            }
            finally
            {
                LockedHelp.ThreadUnLocked(order.ID);
            }

            return Redirect(returnUrl);
        }

        [HttpPost]
        public ActionResult AlipayState()
        {
            var state = new OrderIdString()
            {
                ID = Guid.Empty,
                State = false
            };

            if (Session["AlipayOrderID"] == null)
                return Json(state);

            var id = Guid.Parse(Session["AlipayOrderID"].ToString());

            var order = _context.Orders.Find(id);

            if (order.EnumOrderStatus == EnumOrderStatus.已付款)
            {
                Session["AlipayOrderID"] = null;
                state.ID = id;
                state.State = true;
            }
            else
            {
                state.ID = id;
                state.State = false;
            }

            return Json(state);
        }

        public ActionResult Confirm(Guid id)
        {
            var item = _context.Orders.Find(id);
            if (item.PaySuccess)
            {
                return new HttpStatusCodeResult(200);
            }
            else
                return new HttpStatusCodeResult(400);
        }

        public class OrderIdString
        {
            public Guid ID { get; set; }
            public bool State { get; set; }
        }

        #endregion 阿里支付
    }
}