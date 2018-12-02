using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StorController : Controller
    {
        private static readonly MusicStorEntity.EntityDbContext _context = new MusicStorEntity.EntityDbContext();

        /// <summary>
        /// 显示专辑明细
        /// </summary>
        /// <returns></returns>
        // GET: Stor
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View();
        }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);

        }
    }
}