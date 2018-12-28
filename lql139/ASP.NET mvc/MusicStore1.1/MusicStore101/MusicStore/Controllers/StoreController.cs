using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        /// <summary>
        /// 显示专辑明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detai(Guid id)
        {
            var detail = _context.Albums.Find(id);
            var cmt = _context.Reply.Where(x => x.Album.ID == id && x.ParentReply == null).OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.cmt = _GetHtml(cmt);
            return View(detail);
        }
        /// <summary>
        /// 生成回复的显示html文本
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        private string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            foreach (var item in cmt)
            {
                var sonCmt = _context.Reply.Where(x => x.ParentReply.ID == item.ID).ToList();

                htmlString += " <hr />";
                htmlString += "<div>";
                htmlString += "<img class='comments' src='" +item.Person.Avarda + "'  alt='头像'/>";
                htmlString += "<div  class='comments-foreach-div' id='Content-" + item.ID + "'>";
                htmlString += " <a style='margin-top:5px; margin-left:-10px;'>"+item.Person.Name+"</a><br />";
                htmlString += " <label>"+item.Content+ "</label><br />";

                htmlString+= "  <p style='float:right; '>"+item.CreateDateTime+ "&nbsp;&nbsp;&nbsp;" + "<a href='#'><i class='glyphicon glyphicon-thumbs-up'></i></a>(" + item.Like
                     + ")  <a href='#'><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + item.Hate + ")</p>";

                htmlString += "<h6><a href='#div-editor' class='btn btn-default btn-xs' role='button' onclick=\"javascript:GetQuote('" + item.ID + "');\">回复( " + sonCmt.Count + " )条 </a></h6>";
                htmlString += "</div>";
                htmlString += " <hr/>";
            }
            return htmlString;
        }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            return View(context.Genres.OrderBy(x=>x.Name).ToList());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Commentsadd(string id,string cmt, string reply)
        {
            //判断是否登录
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            //获取当前用户ID
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var album = _context.Albums.Find(Guid.Parse(id));

            var r = new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title = "",
            };

            if (string.IsNullOrEmpty(reply))
            {
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Reply.Find(Guid.Parse(reply));
            }
            var replies = _context.Reply.Where(x => x.Album.ID == album.ID && x.ParentReply == null)
             .OrderByDescending(x => x.CreateDateTime).ToList();
         
            _context.Reply.Add(r);
            _context.SaveChanges();
            return Json(_GetHtml(replies));
        }

    }
}