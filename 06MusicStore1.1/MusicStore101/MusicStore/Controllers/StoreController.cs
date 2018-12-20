using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using MusicStore.ViewModels;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
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

        /// <summary>
        /// 显示所有的分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(x => x.Name).ToList();
            return View(genres);
        }
        ///// <summary>
        ///// 评论页
        ///// </summary>
        ///// <param name="content"></param>
        ///// <returns></returns>
        //public ActionResult Commit(string content)
        //{
        //    return View();
        //}

        ///// <summary>
        ///// 点赞
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Zan(Guid id)
        //{
        //    if (Session["LoginUserSessionModel"] == null)
        //        return Json("nologin");

        //    var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

        //    var commentary = _context.Commentarys.Find(id);
        //    commentary.ThumbsUp++;
        //    _context.SaveChanges();
        //    var htmlString = "";
        //    htmlString = "<span class='glyphicon glyphicon-thumbs-up'></span>&nbsp;&nbsp;( " + commentary.ThumbsUp + " )";
        //    return Json(htmlString);
        //}
    }
}