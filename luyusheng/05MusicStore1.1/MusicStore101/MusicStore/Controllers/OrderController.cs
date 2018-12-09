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
        /// <summary>
        /// 下单页
        /// </summary>
        /// <returns></returns>
        public ActionResult Buy()
        {
            //1.确认用户是否登录 是否登录过期

            //2.查询出当前用户Person 查询该用户的购物项

            //3.创建新的Order对象

            //4.把购物项导入订单明细

            //将订单和明细在视图呈现,验证用户收件人、地址、电话,供用户选项确认要购买专辑
            return View();
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            return Json("");
        }

        /// <summary>
        /// 处理用户提交下单
        /// </summary>
        /// <param name="oder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Buy(Order oder)
        {
            return View();
        }

        /// <summary>
        /// 浏览用户订单
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}