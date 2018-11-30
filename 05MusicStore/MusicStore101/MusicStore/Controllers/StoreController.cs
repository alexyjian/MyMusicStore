using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly MusicContext _context = new MusicContext();
        // GET: Store
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View(detail);
        }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x=>x.Genre.ID==id).OrderByDescending(x=>x.PublisherDate).ToList();
            return View(list);
        }
    }
}