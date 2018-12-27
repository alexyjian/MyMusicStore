using MusicStore.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
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

        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Store
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            var cmt = _context.Reoly.Where(x => x.Album.ID == id && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);
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
        /// 回复生成html文本
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        public string _GetHtml(List<Reply>cmt)
        {
            //var detail = _context.Albums.Find(id);
            //var cmt = _context.Reoly.Where(x => x.Album.ID == id && x.ParentReply == null)
            //    .OrderByDescending(x => x.CreateDateTime).ToList();
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body'>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + "  发表于" +
                              item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                //查询当前回复的下一级回复
                var sonCmt = _context.Reoly.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6><a href='#' class='reply'>回复</a>(<a href='#' class='reply'>" + sonCmt.Count + "</a>)条" +
                              "<a href='#' class='reply' style='margin:0 20px 0 40px'><i class='glyphicon glyphicon-thumbs-up'></i>(" +
                              item.like + ")</a><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";
                htmlString += "</div>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCmt(string id,string cmt,string reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
                LoginUserSessionModel).Person.ID);
            var album = _context.Albums.Find(Guid.Parse(id));

            //创建对象
            var r = new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title=""
            };
            //父级回复
            if(string.IsNullOrEmpty(reply))
            {
                //顶级回复
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Reoly.Find(Guid.Parse(reply));
            }
            _context.Reoly.Add(r);
            _context.SaveChanges();
            return Json("OK");
        }

        /// <summary>
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            var genre = _context.Genres.OrderBy(x => x.Name).ToList();
            return View(genre);
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ActionResult Commit(string content)
        {
            return View();
        }

    }
}