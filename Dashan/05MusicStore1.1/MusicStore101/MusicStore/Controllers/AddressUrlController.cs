using MusicStore.ViewMoldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class AddressUrlController : Controller
    {
         /// <summary>
        ///设置收件人地址
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }  
    }
}