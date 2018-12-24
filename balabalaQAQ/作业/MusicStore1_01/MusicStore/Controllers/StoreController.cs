using MusicStore.ViewModels;
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
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: Store

        public ActionResult Detail(Guid id)
        {
            _context.ContextOptions.ProxyCreationEnabled = false;
            if ((Session["LoginUserSessionModel"] as LoginUserSessionModel) == null)
            {
                ViewBag.img = "/Content/images/boys.jpg";
                ViewBag.name = "请登录";
            }
            else
            {
                ViewBag.img = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Avarda;
                ViewBag.name = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Name;
            }

            var Albums = _context.Albums.SingleOrDefault(x =>x.ID == id);
         
            return Json(Albums, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }

    }
}