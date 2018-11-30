using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public static readonly MusicContext _Context=new MusicContext();
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            var detail = _Context.Ablums.Find(id);
            return View(detail);
        }
        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _Context.Ablums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToString();
            return View(list);
        }
    }
}