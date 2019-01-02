using MusicStore.ViewModels;
using MusicStoreEntities.UserAndRole;
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
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Storo
            private static readonly EntityDbContext _context = new EntityDbContext { };
            public ActionResult Detail(Guid id)
            {
                var deteil = _context.Album.Find(id);
            var cmt = _context.Replies.Where(x => x.Album.ID == id && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);
            return View(deteil);

            }

        public ActionResult LikeReply(string id, bool Title, string Albumid)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);

            var ID = Guid.Parse(id);
            var AlbumiID = Guid.Parse(Albumid);
            var reply = _context.Replies .Find(ID);
            //判断该用户是否对此条评论点赞或者踩
            if (_context.LikeReply.Where(x => x.Person.ID == person.ID && x.Reply.ID == ID).Count() == 0)
            {
                //Title传的是bool
                if (Title)
                {
                    reply.Like += 1;
                }
                else
                {
                    reply.Hate += 1;
                }
                //吧赞还是踩添加到数据库
                var likeReply = new LikeReply()
                {
                    IsNotLike = Title,
                    Person = person,
                    Reply = _context.Replies.Find(ID),
                };
                _context.LikeReply.Add(likeReply);
                _context.SaveChanges();
                //刷新局部页面
                var Cmt = _context.Replies.Where(x => x.Album.ID == AlbumiID && x.ParentReply == null).OrderByDescending(x => x.CreateDateTime).ToList();
                var htmlString = "";

                htmlString += _GetHtml(Cmt);
                return Json(htmlString);
            }
            else
            {
                return Json("");
            }
        }

        /// <summary>
        /// 生成回复的显示html文本
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        private string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-"+item.ID+"'>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + " 发表于" +
                              item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
               htmlString += "</div>";
                //查询当前回复的下一级回复
                var sonCmt = _context.Replies.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6><a href='#div-editor' class='reply'onclick=\"javascript:GetQuote('" + item.ID+ "');\">回复</a>(<a href='#' data-toggle='modal' data-target='#myModal' onclick=\"ShowCmt('" + item.ID+"')\">"+ sonCmt.Count + "</a>)条" +
                             "<a href='#' class='reply' style='margin:0 20px 0 40px'><i class='glyphicon glyphicon-thumbs-up'></i>(" +
                              item.Like + ")</a><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";

                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;
        }

        [HttpPost]
        [ValidateInput(false)]//关闭验证
        public ActionResult AddCmt(string id, string cmt, string reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            //if (Session["LoginUserSessionModel"] == null)
            //    return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var album = _context.Album.Find(Guid.Parse(id));

            //创建回复对象
            var r = new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title = ""
            };
            //父级回复
            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复,ParentReply为空
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Replies.Find(Guid.Parse(reply));
            }
            _context.Replies.Add(r);
            _context.SaveChanges();
            //局部刷新显示成最新的评论
            var replies = _context.Replies.Where(x => x.Album.ID == album.ID && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            return Json(_GetHtml(replies));
        }
        [HttpPost]
        public ActionResult showCmts(string pid)
        {

            var id = Guid.Parse(pid);
            var htmlString = "";
            htmlString += "<div class='modal-header'>";
            htmlString += "<h4 class='modal-title' id='myModalLabel'>";
            //查询出原回复
            var fatherCmt = _context.Replies .Find(id);
            //原回复
            htmlString += "<div class='media-left'>";
            htmlString += "<img class='media-object' src='" + fatherCmt.Person.Avarda +
                          "' alt='头像' style='width:40px;border-radius:50%;'>";
            htmlString += "</div>";
            htmlString += "<h5 class='media-heading'>" + fatherCmt.Person.Name + "  发表于" +
                              fatherCmt.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
            htmlString += fatherCmt.Content;

            htmlString += " </h4>";
            htmlString += "</div>";
            htmlString += "<div class='modal-body'>";
            //子回复
            //查询出子回复
            var sonCmt = _context.Replies.Where(x => x.ParentReply.ID == id).ToList();
            foreach (var item in sonCmt)
            {
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + "  发表于" +
                                  item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;

            }
            htmlString += "</div>";
            htmlString += "<div class='modal-footer'>";
            htmlString += "</div>";
            return Json(htmlString);


        }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Album.Where(x => x.Genre.ID == id)
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


       
    }
}