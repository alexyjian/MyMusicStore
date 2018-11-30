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
        /// <summary>
        /// 显示专辑明细
        /// </summary>
          private static readonly EntityDbContext  _context = new EntityDbContext();
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View(detail);
        }
        /// <summary>
        /// 按分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Browaer(Guid id)
        {

        }
    }
}