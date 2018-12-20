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
        private static readonly EntityDbContext _dbContext = new EntityDbContext();
        /// <summary>
        /// 明细页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            var detail = _dbContext.Albums.Find(id);
            ViewBag.AvardaUrl = Session["LoginUserSessionModel"] == null ? "/Content/Images/Body.jpg": (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Avarda;

            return View(detail);
        }

        /// <summary>
        /// 分类页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _dbContext.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }

        /// <summary>
        /// 评论页
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ActionResult Commit(string content)
        {
            return View();
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Zan(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Home") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var commentary = _dbContext.Commentarys.Find(id);
            commentary.ThumbsUp++;
            _dbContext.SaveChanges();
            var htmlString = "";
            htmlString = "<span class='glyphicon glyphicon-thumbs-up'></span>&nbsp;&nbsp;( " + commentary.ThumbsUp + " )";
            return Json(htmlString);
        }
    }
}