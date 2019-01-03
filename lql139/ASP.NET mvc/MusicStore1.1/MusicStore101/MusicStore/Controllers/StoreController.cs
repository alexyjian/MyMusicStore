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

                htmlString+= "  <p style='float:right; '>"+item.CreateDateTime+ "&nbsp;&nbsp;&nbsp;" +
                    "<a  onclick=\"javascript:Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up'></i></a>(" + item.Like
                     + ")  <a  onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + item.Hate + ")</p>";

                htmlString += "<h6><a href='#div-editor' class='btn btn-default btn-xs' role='button' onclick=\"javascript:GetQuote('" + item.ID + "','" + item.ID + 
                    "');\">回复</a><a class='btn btn-default btn-xs' role='button'  onclick=\"javascript:ShowCmt('" + item.ID + "');\"> ( " 
                 + sonCmt.Count + " )条 <span class='caret'></span></a></h6>";

                htmlString += "</div>";
                htmlString += " <hr/>";
            }
            return  htmlString;
        }

        [HttpPost]
        public ActionResult Like(Guid id)
            {
            //1.判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "Home") });
            //2.判断用户是否对这条回复点过赞或踩
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var comm = _context.LikeReply.SingleOrDefault(x => x.Person.ID == person.ID && x.Reply.ID == id);
            //3.保存  reply实体中like+1或hate+1  LikeReply添加一条记录
            if (comm==null)
                {
                var replys = _context.Reply.SingleOrDefault(x => x.ID == id);
                replys.Like += 1;
                comm = new LikeReply()
                    {
                    IsNotLike = true,
                    Person = _context.Persons.Find(person.ID),
                    Reply=replys,
                    };
                _context.LikeReply.Add(comm);
                _context.SaveChanges();
                //生成html 注入视图
                return Content("<script>alert('点赞成功!!!');</script>");
                }
            else
                {
                     return Content("<script>alert('你已给过此评论评价!!!');</script>");
                }
            }

        [HttpPost]
        public ActionResult Hate(Guid id)
            {
            //1.判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "Home") });
            //2.判断用户是否对这条回复点过赞或踩
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var comm = _context.LikeReply.SingleOrDefault(x => x.Person.ID == person.ID && x.Reply.ID == id);
            //3.保存  reply实体中like+1或hate+1  LikeReply添加一条记录
            if (comm == null)
                {
                var replys = _context.Reply.SingleOrDefault(x => x.ID == id);
                replys.Hate += 1;
                comm = new LikeReply()
                    {
                    IsNotLike = false,
                    Person = _context.Persons.Find(person.ID),
                    Reply = replys,
                    };
                _context.LikeReply.Add(comm);
                _context.SaveChanges();
                //生成html 注入视图

                return Content("<script>alert('点踩成功!!!');</script>");
                }
            else
                {
                return Content("<script>alert('你已给过此评论评价!!!');</script>");
                }
            }

        [HttpPost]
        public ActionResult showCmts(string pid)
            {
            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _context.Reply.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime).ToList();
            //原回复
            var pcmt = _context.Reply.Find(id);

            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主&nbsp;&nbsp;</em>" + pcmt.Person.Name + "&nbsp;&nbsp;发表于" + pcmt.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += " </h4> </div>";

            htmlString += "<div class=\"modal-body\">";
            //子回复
            htmlString += "<ul class='media-list' style='margin-left:20px;'>";
            foreach (var item in cmts)
                {
                htmlString += "<li class='media'>";
                htmlString += "<div>";
                htmlString += "<img class='comments' src='" + item.Person.Avarda + "'  alt='头像'/>";
                htmlString += "<div  class='comments-foreach-div' id='Content-" + item.ID + "'>";
                htmlString += " <a style='margin-top:5px; margin-left:-10px;'>" + item.Person.Name + "</a><br />";
                htmlString += " <label>" + item.Content + "</label><br />";

                htmlString += "  <p style='float:right; '>" + item.CreateDateTime + "&nbsp;&nbsp;&nbsp;" +
                    "<a  onclick=\"javascript:Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up'></i></a>(" + item.Like
                     + ")  <a  onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + item.Hate + ")</p>";

                htmlString += "<h6><a href='#div-editor' class='btn btn-default btn-xs' role='button' onclick=\"javascript:GetQuote('" + item.ParentReply.ID + "','" + item.ID
                    + "');\">回复</a></h6>";

                htmlString += "</div>";
                htmlString += "</li>";
                }
            htmlString += "</ul>";
            htmlString += "</div><div class=\"modal-footer\"></div></hr>";
            return Json(htmlString);
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