using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        // GET: Store
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albuns.Find(id);
            return View(detail);
        }
        //
        public ActionResult browser(Guid id)
        {
            var list = _context.Albuns.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublsherDate).ToList();
            return View(list);
        }

        public ActionResult Index()
        {
            var list = _context.Genres.OrderByDescending(x => x.Name).ToList();
            var list1 = _context.Albuns.OrderByDescending(x => x.PublsherDate).ToList();
            
            return View(list);

        }
    }
}