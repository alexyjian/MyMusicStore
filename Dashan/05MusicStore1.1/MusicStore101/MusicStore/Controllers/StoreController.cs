using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewMoldels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;

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
            var cmt = _context.Plaries.Where(x => x.Album.ID == id && x.ReplyPlaries == null)
                .OrderByDescending(x => x.MusicPlayTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);
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
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda + "'alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'><em>" + item.Person.Name + "</em>&nbsp;&nbsp;发表于" +
                              item.MusicPlayTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                //查询当前回复的下一级回复
                var sonCmt = _context.Plaries.Where(x => x.ReplyPlaries.ID == item.ID).ToList();
                htmlString += "<h5><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ID + "','" + item.ID + "');\">回复</a>(<a href='#' class='reply'  onclick=\"javascript:ShowCmt('" + item.ID + "');\">" + sonCmt.Count + "</a>)条" +
                              "<a href='#' class='reply' style='margin:0 20px 0 40px'   onclick=\"javascript:Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up'></i>(" + item.Like + ")</a>" +
                              "<a href='#' class='reply' style='margin:0 20px'   onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.hate + ")</a></h5>";

                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;
        }

        [HttpPost]
        [ValidateInput(false)]   //关闭验证
        public ActionResult AddCmt(string id, string cmt, string reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
                LoginUserSessionModel).Person.ID);
            var album = _context.Albums.Find(Guid.Parse(id));

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
                //顶级回复, ParentReply为空
                r.ReplyPlaries = null;
            }
            else
            {
                r.ReplyPlaries = _context.Plaries.Find(Guid.Parse(reply));
            }
            _context.Plaries.Add(r);
            _context.SaveChanges();

            //局部刷新显示成最新的评论
            var replies = _context.Plaries.Where(x => x.Album.ID == album.ID && x.ReplyPlaries == null)
                .OrderByDescending(x => x.MusicPlayTime).ToList();
            return Json(_GetHtml(replies));
        }

        [HttpPost]
        public ActionResult ShowCmts(string pid)
        {
            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _context.Plaries.Where(x => x.ReplyPlaries.ID == id).OrderByDescending(x => x.MusicPlayTime).ToList();
            //原回复
            var pcmt = _context.Plaries.Find(id);
            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\"aria-hidden=\"true\">×</button>";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主&nbsp;&nbsp;</em>" + pcmt.Person.Name + "&nbsp;&nbsp;发表于" + pcmt.MusicPlayTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += " </h4></div>";

            htmlString += "<div class=\"modal-body\">";
            //子回复
            htmlString += "<ul class='media-list' style='margin-left:20px;'>";
            foreach (var item in cmts)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='"+item.Person.Avarda+"'alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'><em>"+item.Person.Name+"</em>&nbsp;&nbsp;发表于" +
                              item.MusicPlayTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                htmlString +="<h6><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('"+item.ReplyPlaries.ID+"','"+item.ID+"');\">回复</a>" +
                              "<a href='#' class='reply' style='margin:0 20px 0 40px'   onclick=\"javascript:Like('"+item.ID+"');\"><i class='glyphicon glyphicon-thumbs-up'></i>("+ item.Like+")</a>" +
                              "<a href='#' class='reply' style='margin:0 20px'   onclick=\"javascript:Hate('"+item.ID+"');\"><i class='glyphicon glyphicon-thumbs-down'></i>("+item.hate+")</a></h6>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            htmlString += "</div><div class=\"modal-footer\"></div>";
            return Json(htmlString);
        }


        public string _GetHtmlModal(Reply pcmt, List<Reply> cmts)
        {
            var htmlString = "";

            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主&nbsp&nbsp</em>" + pcmt.Person.Name + "  发表于" + pcmt.MusicPlayTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += " </h4> </div>";

            htmlString += "<div class=\"modal-body\">";
            //子回复
            htmlString += "<ul class='media-list' style='margin-left:20px;'>";
            foreach (var item in cmts)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' id='ReplyImg' src='" + item.Person.Avarda + "' alt=\"头像\">";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'><em>" + item.Person.Name + "</em>&nbsp;&nbsp;回复  " + item.ReplyPlaries.Person.Name + ": " + item.ReplyPlaries.Content + " </h5> ";
                htmlString += item.Content;
                htmlString += "</div>";
                htmlString += "<h6 style =\"margin-bottom:5px; border-bottom:1px solid #c6e6e8\">" + item.MusicPlayTime.ToString("yyyy年MM月dd日 hh时mm分ss秒") +
                              "<a href='#div-editor' style='margin-left:20px;' class='reply' onclick=\"javascript:GetQuote('" + item.ReplyPlaries.ID + "','" + item.ID + "');\">回复</a>" +
                              "<a href='#' class='reply' style='margin-left:20px;'   onclick=\"javascript:Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up'></i>(" + item.Like + ")</a>" +
                              "<a href='#' class='reply' style='margin-left:20px;'   onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.hate + ")</a></h6>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            htmlString += "</div><div class=\"modal-footer\"></div>";

            return htmlString;
        }


        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="pid">回复id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Like(Guid pid)
        {
            //初始化存储对象
            var status = new LikeStatus()
            {
                Status = "",
                Html = "",
            };
            //1判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
            {
                status = new LikeStatus()
                {
                    Status = "noLogin",
                    Html = "",
                };
                return Json(status);
            }
            //2.判断用户是否对这条回复点过赞或踩
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var reply = _context.Plaries.Find(pid);//当前评论
            //是否有踩赞记录
            var IsLike = _context.Likes.SingleOrDefault(x => x.Reply.ID == reply.ID && x.Person.ID == person.ID);


            //3.保存  reply实体中like+1或hate+1  LikeReply添加一条记录
            if (IsLike == null || IsLike.Person.ID != person.ID)
            {

                reply.Like += 1;//添加赞数
                var ok = new Like()
                {
                    Reply = reply,
                    IsNotLike = true,
                    Person = person
                };
                _context.Likes.Add(ok);
                _context.SaveChanges();
            }
            //点赞失败，已经点过了
            else
            {
                //赞或踩过了 判断
                if (IsLike.IsNotLike == false)
                {
                    status.Status = "false";
                    status.Html = "";
                    return Json(status);
                }
                reply.Like -= 1;
                _context.Likes.Remove(IsLike);
                _context.SaveChanges();
            }

            //根据是否有上级回复 刷新detail 或 modal
            if (reply.ReplyPlaries == null)
            {
                //显示评论、排序
                var albumSay = _context.Plaries.Where(x => x.Album.ID == reply.Album.ID && x.ReplyPlaries == null)
                    .OrderByDescending(x => x.MusicPlayTime).ToList();

                status.Status = "Parent";
                status.Html = _GetHtml(albumSay);
            }
            else
            {
                //查询子回复
                var pcmt = _context.Plaries.Find(pid).ReplyPlaries;//主
                var cmts = _context.Plaries.Where(x => x.ReplyPlaries.ID == pcmt.ID).OrderByDescending(x => x.MusicPlayTime).ToList();


                status.Status = "Son";
                status.Html =_GetHtmlModal(pcmt, cmts);
            }
            //生成html 注入视图
            return Json(status);
        }


        /// <summary>
        /// 踩
        /// </summary>
        /// <param name="pid">回复id</param>
        /// <returns></returns>
        public ActionResult Hate(Guid pid)
        {
            //初始化存储对象
            var status = new LikeStatus()
            {
                Status = "",
                Html = "",
            };
            //1判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
            {
                status = new LikeStatus()
                {
                    Status = "noLogin",
                    Html = "",
                };
                return Json(status);
            }
            //2.判断用户是否对这条回复点过赞或踩
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var reply = _context.Plaries.Find(pid);//当前评论
            //是否有踩赞记录
            var IsLike = _context.Likes.SingleOrDefault(x => x.Reply.ID == reply.ID && x.Person.ID == person.ID);


            //3.保存  reply实体中like+1或hate+1  LikeReply添加一条记录
            if (IsLike == null || IsLike.Person.ID != person.ID)
            {

                reply.hate += 1;//添加赞数
                var ok = new Like()
                {
                    Reply = reply,
                    IsNotLike = false,
                    Person = person
                };
                _context.Likes.Add(ok);
                _context.SaveChanges();
            }
            //点赞失败，已经点过了
            else
            {
                //赞或踩过了 判断
                if (IsLike.IsNotLike == true)
                {
                    status.Status = "false";
                    status.Html = "";
                    return Json(status);
                }
                reply.hate -= 1;
                _context.Likes.Remove(IsLike);
                _context.SaveChanges();
            }

            //刷新detail 或 modal
            if (reply.ReplyPlaries == null)
            {
                //显示评论、排序
                var albumSay = _context.Plaries.Where(x => x.Album.ID == reply.Album.ID && x.ReplyPlaries == null)
                    .OrderByDescending(x => x.MusicPlayTime).ToList();

                status.Status = "Parent";
                status.Html = _GetHtml(albumSay);
            }
            else
            {
                //查询子回复
                var pcmt = _context.Plaries.Find(pid).ReplyPlaries;//主
                var cmts = _context.Plaries.Where(x => x.ReplyPlaries.ID == pcmt.ID).OrderByDescending(x => x.MusicPlayTime == x.MusicPlayTime).ToList();


                status.Status = "Son";
                status.Html = _GetHtmlModal(pcmt, cmts);
            }
            //生成html 注入视图
            return Json(status);
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
    }

    public class LikeStatus
    {
        public string Status { get; set; }
        public string Html { get; set; }
    }
}