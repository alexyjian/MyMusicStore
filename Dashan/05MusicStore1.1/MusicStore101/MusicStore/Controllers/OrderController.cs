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
     
        public ActionResult Buy()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            return Json ("");
        }

        /// <summary>
        /// 处理提交下单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ActionResult Buy(Order order)
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