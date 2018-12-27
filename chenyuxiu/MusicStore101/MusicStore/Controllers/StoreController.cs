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
        // GET: Store
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            var cmt = _context.Reply.Where(x => x.Album.ID == id && x.ParentReoly == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);
            return View(detail);
        }

        /// <summary>
        /// 生成回复的显示html文本
        /// </summary>
        /// <param name="cmt"></param>
        private string _GetHtml(List<Reply>cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var iteme in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left>";
                htmlString += "<img class='media-object'src='"+iteme.Person.Avarda+
                    "'alt='头像'style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body'>";
                htmlString += "<h5 class='media-hesding'>" + iteme.Person.Name + "发表于" +
                    iteme.CreateDateTime.ToString("yyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += iteme.Content;
                //查询当前回复的下一级回复
                var sonCmt =_context.Reply.Where(x => x.ParentReoly.ID == iteme.ID).ToList();
                htmlString +="<h6>回复(<a href='#'>"+ sonCmt.Count + "</a>)条" + "  <a href='#'><i class='glyphicon glyphicon-thumbs-up'></i></a>(" +
iteme.Like + ")  <a href='#'><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + iteme.Hate + ")</h6>";
                htmlString += "</div>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;
        }


        [HttpPost]
        [ValidateInput(false)] //关闭验证
        public ActionResult AddCmt(string id, string cmt, string reply)
        {

            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
          LoginUserSessionModel).Person.ID);
            var alnum = _context.Albums.Find(Guid.Parse(id));

            //创建回复对象
            var r = new Reply()
            {
                Album = alnum,
                Person = person,
                Content = cmt,
            };
            //父级回复
            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复.ParentReply为空
                r.ParentReoly = null;
            }
            else
            {
                r.ParentReoly = _context.Reply.Find(Guid.Parse(reply));
            }
            _context.Reply.Add(r);
            _context.SaveChanges();

            //局部刷新显示成最新的评论
            var reolies = _context.Reply.Where(x => x.Album.ID == alnum.ID&& x.ParentReoly == null)
               .OrderByDescending(x => x.CreateDateTime).ToList();


            return Json("OK");

        }

        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
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
    }
}