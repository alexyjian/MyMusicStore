using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using MusicStore.ViewMoldels;

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
            var cmt = _context.Plaries.Where(x => x.Album.ID == id && x.ReplyPlaries == null).OrderByDescending(x => x.MusicPlayTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);
            return View(detail);

        

        }
        /// <summary>
        /// 封装重构 HTML
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        public string _GetHtml(List<Reply>cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<a href = '#'><img class='media-object' src='" + item.Person.Avarda + "'alt='头像' style='width:40px;border-radius:50%;'></a>";
                htmlString += "</div>";
                htmlString += "<div class='media-body'>";
                htmlString += "<h4 class='media-heading'>" + item.Person.Name + "发表于" + item.MusicPlayTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h4>";
                htmlString += item.Content;

                //查询当前回复的下一级
                var sonCmt = _context.Plaries.Where(x => x.ReplyPlaries.ID == item.ID).ToList();
                htmlString += "<h5><a href='#'>回复</a>("+ sonCmt.Count + ")条  &nbsp &nbsp" + "<a href ='#'><i class='glyphicon glyphicon-heart'></i></a>("+ item.Like + ")   &nbsp &nbsp</a><a href = '#'><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + item.hate+")</a></h5>";
                htmlString += "</div>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;

        }
        /// <summary>
        /// 添加 回复、评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmt"></param>
        /// <param name="reply"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]//关闭验证
        public ActionResult AddCmt (string id, string cmt, string reply)
        {
            //判断是否登录
            if (Session["loginUserSessionModel"] == null)
                return Json("nologin");

            //获取用户
            var person =_context.Persons.Find((Session["LoginUserSessionModel"] as
                LoginUserSessionModel).Person.ID);
            var album = _context.Albums.Find(Guid.Parse(id));

            //创建回复对象
            var r= new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title = ""
            };

            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复
                r.ReplyPlaries = null;
            }
            else
            {
                r.ReplyPlaries = _context.Plaries.Find(Guid.Parse(reply));
            }
            _context.Plaries.Add(r);
            //保存数据库
            _context.SaveChanges();

            //局部刷新 最新时间
            var replies = _context.Plaries.Where(x => x.Album.ID == album.ID && x.ReplyPlaries == null).OrderByDescending(x => x.MusicPlayTime).ToList();
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
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(x =>x.Name).ToList();
            return View(genres);//返回到视图
        }
    }
}