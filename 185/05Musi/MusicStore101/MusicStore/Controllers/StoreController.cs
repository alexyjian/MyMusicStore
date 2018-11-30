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
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Storo
            private static readonly EntityDbContext _context = new EntityDbContext { };
            public ActionResult Detail(Guid id)
            {
                var deteil = _context.Album.Find(id);
                return View(deteil);

            }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Album.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }
        
    }
}