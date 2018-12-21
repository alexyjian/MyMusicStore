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
        [HttpPost]
        public ActionResult Commit(string id, string str)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var Album = _dbContext.Albums.Find(Guid.Parse(id));
            var com = new Commentary()
            {
                Context = str,
                Album = Album,
                Person = _dbContext.Persons.Find(person.ID)
            };
            Album.Commentarys.Add(com);
            _dbContext.SaveChanges();

            var pls = _dbContext.Commentarys.Where(x => x.Album.ID == Album.ID).OrderByDescending(x => x.PublisherDate).ToList();
            string htmlString = "";
            foreach (var item in pls)
            {
                htmlString += "<div class='pl-list'>";
                htmlString += "<img class='pl-Avarda MyAvarda' src='" + @item.Person.Avarda + "' />";
                htmlString += "<div class='pl-user'>";
                htmlString += "<a href='#'>" + @item.Person.Name + "</a>：" + @item.Context + "</div>";
                htmlString += "<p class='user-ment text-right'>";
                htmlString += "<a id=" + @item.ID + " href ='#' onclick=" + '"' + "zan('" + @item.ID + "')" + '"' + "><span class='glyphicon glyphicon-thumbs-up'></span>&nbsp;&nbsp;( " + @item.ThumbsUp + " )</a>";
                htmlString += "<span class='text-muted time'>" + @item.PublisherDate + "</span></p></div>";
            }
            return Json(htmlString);
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
                return Json("nologin");

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