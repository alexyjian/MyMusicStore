using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore101.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <returns></returns>
        // GET: Store
        public ActionResult Detail(Guid id)
        {
            var datail = _context.Albums.Find(id);
            return View(datail);
        }
        /// <summary>
        /// 按分类专辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
         }
    }
   
}