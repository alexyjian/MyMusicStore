using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        public static readonly MusicContext _Context = new MusicContext();
        // GET: My
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MusicStoreEntity.MyAddressee user)
        {
            var name = new MyAddressee()
            {
                AddressPerson = user.AddressPerson,
                Address = user.Address,
                MobilNumber = user.MobilNumber,
                Email = user.Email
            };
           
            return Content("<script>alert('保存成功！');location.href='" + Url.Action("Buy", "Order") + "'</script>");

        }
    }
}