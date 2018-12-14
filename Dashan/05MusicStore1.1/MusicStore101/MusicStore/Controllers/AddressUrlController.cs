using MusicStore.ViewMoldels;
using MusicStoreEntity;
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
        public ActionResult My(MusicStoreEntity.MyAddressUrl model)
        {
            var user = new MyAddressUrl()
            {

                AddressPerson = model.AddressPerson,
                Address= model.Address,
                MobilNumber = "18346464645",
            };
            return View();
           
        }


    }
}