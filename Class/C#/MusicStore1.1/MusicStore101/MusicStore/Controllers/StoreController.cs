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
            ViewBag.AvardaUrl = Session["LoginUserSessionModel"] == null ? "/Content/Images/Body.jpg" : (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.Avarda;
            string str = NewMethod(_dbContext.Albums.Find(id));
            ViewBag.Cmt = str == "" ? "<div class='text-center text-muted user-ment'>还没有评论呢，快来抢沙发~</div>" : str;
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
        /// 评论
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Commit(string id, string str, string reply)
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
            com.commentary = reply == "" ? null : _dbContext.Commentarys.Find(Guid.Parse(reply));
            Album.Commentarys.Add(com);
            _dbContext.SaveChanges();
            string htmlString = NewMethod(Album);
            return Json(htmlString);
        }

        /// <summary>
        /// 提取
        /// </summary>
        /// <param name="Album"></param>
        /// <returns></returns>
        private static string NewMethod(Album Album)
        {
            var pls = _dbContext.Commentarys.Where(x => x.Album.ID == Album.ID).OrderByDescending(x => x.PublisherDate).ToList();
            string htmlString = "";
            foreach (var item in pls)
            {
                htmlString += "<div id=" + item.ID + " class='pl-list'>";
                htmlString += "<img class='pl-Avarda MyAvarda' src='" + @item.Person.Avarda + "' />";
                htmlString += "<div class='pl-user'>";
                htmlString += "<a href='#'>" + @item.Person.Name + "</a>：" + @item.Context;
                if (item.commentary != null)
                {
                    htmlString += "<div class='fu-hf'>";
                    htmlString += "<a href='#'>" + @item.commentary.Person.Name + "：</a>" + @item.commentary.Context + "</div>";
                }
                htmlString += "</div><p class='user-ment text-right'>";
                htmlString += "<a data-likeid=" + item.ID + " href ='#' onclick=\"zan('" + @item.ID
                    + "')\"><span class='glyphicon glyphicon-thumbs-up'></span>&nbsp;&nbsp;( " + @item.ThumbsUp
                    + " )</a><a href='javascript:;' class='hf' data-replyid=\"'" + item.ID + "'\" onclick=\"div_reply();\">回复</a>";
                htmlString += "<span class='text-muted time'>" + @item.PublisherDate.ToString("MM月dd日 HH:mm") + "</span></p></div>";
            }

            return htmlString;
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
            var a = _dbContext.Commentarys.Find(id).Album;
            var htmlString = NewMethod(a);
            return Json(htmlString);
        }
    }
}