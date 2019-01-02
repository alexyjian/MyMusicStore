
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
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        // GET: Store
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id">专辑ID</param>
        /// <returns></returns>
        public ActionResult Detail(string id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Home") });
            var ID = Guid.Parse(id);
            var detail = _context.Albuns.Find(ID);
          //查询出本专辑，传到视图
            ViewBag.detail = detail;
            //var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var Cmt = _context.Replys.Where(x => x.Album.ID == ID && x.ParentReply==null).OrderByDescending(x => x.CreateDateTime).ToList();
            //在显示评论那里注入html
            ViewBag.Cmt = _GetHtml(Cmt);
            return View();
        }

       /// <summary>
       ///   赞 和 踩
       /// </summary>
       /// <param name="id">评论与回复的ID</param>
       /// <param name="Title">是赞还是踩</param>
       /// <param name="Albumid">专辑ID</param>
       /// <returns></returns>
        [HttpPost]
        public ActionResult LikeReply(string id, bool Title,string Albumid)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            
            var ID = Guid.Parse(id);
            var AlbumiID = Guid.Parse(Albumid);
            var reply = _context.Replys.Find(ID);
            //判断该用户是否对此条评论点赞或者踩
            if (_context.LikeReplys.Where(x => x.Person.ID == person.ID && x.Reply.ID == ID).Count()==0)
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
                    Reply = _context.Replys.Find(ID),
                };
                _context.LikeReplys.Add(likeReply);
                _context.SaveChanges();
                //刷新局部页面
                var Cmt = _context.Replys.Where(x => x.Album.ID == AlbumiID && x.ParentReply == null).OrderByDescending(x => x.CreateDateTime).ToList();
                var htmlString = "";

                htmlString += _GetHtml(Cmt);
                return Json(htmlString);
            }
            else
            {
                var Cmt = _context.Replys.Where(x => x.Album.ID == AlbumiID && x.ParentReply == null).OrderByDescending(x => x.CreateDateTime).ToList();
                var htmlString = "";
                htmlString += _GetHtml(Cmt);
                return Json(htmlString);
            }
        }
        /// <summary>
        /// HTML注入
        /// </summary>
        /// <param name="Cmt"></param>
        /// <returns></returns>
        private string _GetHtml(List<Reply> Cmt)
        {

            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in Cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + "  发表于" +
                              item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                //查询当前回复的下一级回复
                var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6 class = 'LikeHateReply'><a href=javascript:;' class='reply' onclick=\"javascript:GetQuote('" + item.ID +
                              "');\">回复</a>(<a href='javascript:;' data-toggle='modal' data-target='#myModal'   onclick=\"ShowCmt('" + item.ID + "')\">" + sonCmt.Count + "</a>)条" +
                              "<a href='javascript:;' class='Like' onclick = LikeReply('" + item.ID + "','true') style='margin:0 20px 0 40px'><i class='glyphicon glyphicon-thumbs-up'></i>(" +
                              item.Like + ")</a><a href='javascript:;' class='LikeReply' onclick = LikeReply('" + item.ID + "','false') style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";

                htmlString += "</li>";
           
            }
            htmlString += "</ul>";
            return htmlString;
        }
        /// <summary>
        /// 回复添加与显示
        /// </summary>
        /// <param name="pid">需要回复的评论ID</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult WShowCmts(string pid)
        {
            var id =Guid.Parse(pid);
            var htmlString = "";
            htmlString +="<div class='modal-header'>";
            htmlString += "<h4 class='modal-title' id='myModalLabel'>";
            //查询出原回复
            var fatherCmt = _context.Replys.Find(id);
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
            var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == id).ToList();
            foreach(var item in sonCmt)
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

            //
          public ActionResult browser(Guid id)
        {
            var list = _context.Albuns.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublsherDate).ToList();
            return View(list);
        }
        /// <summary>
        /// 主页显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Home") });
            var list = _context.Genres.OrderByDescending(x => x.Name).ToList();
            //var list1 = _context.Albuns.OrderByDescending(x => x.PublsherDate).ToList();

            return View(list);

        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmt"></param>
        /// <param name="reply"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCmt(string id, string cmt, string reply)
        {
            //判断是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Home") });
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var album = _context.Albuns.Find(Guid.Parse(id));//查询出当前评论的专辑

            //添加到数据库
            var r = new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title = ""
            };
            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复
                r.ParentReply = null;
            }
            
            else
            {
                //子回复
              var   replyID = Guid.Parse(reply);
                r.ParentReply = _context.Replys.Find(replyID);
            }

            var Id = Guid.Parse(id);


            _context.Replys.Add(r);
            _context.SaveChanges();
            //局部刷新界面注入html
            var Cmt = _context.Replys.Where(x => x.Album.ID == Id && x.ParentReply == null).OrderByDescending(x => x.CreateDateTime).ToList();
            var htmlString = "";

            htmlString += _GetHtml(Cmt);
                       //ViewBag.Cmt = _GetHtml(Cmt);
            return Json(htmlString);
        }

    }
}






























//我的


//using MusicStore.ViewModels;
//using MusicStoreEntity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace MusicStore.Controllers
//{
//    public class StoreController : Controller
//    {
//        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
//        // GET: Store
//        /// <summary>
//        /// 显示专辑的明细
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public ActionResult Detail(Guid id)
//        {
//            if (Session["LoginUserSessionModel"] == null)
//                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
//            var detail = _context.Albuns.Find(id);
//            ViewBag.detail = detail;
//            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
//            try { ViewBag.Reply = _context.Replys.Where(x => x.Album.ID == id&&x.Title=="评论").OrderBy(x=>x.CreateDateTime).ToList(); }
//            catch { }
//            try { ViewBag.ParentReply = _context.Replys.Where(x => x.Album.ID == id&&x.Title=="回复").OrderBy(x => x.CreateDateTime).ToList(); }
//            catch { }

//            return View();
//        }
//        //
//        public ActionResult browser(Guid id)
//        {
//            var list = _context.Albuns.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublsherDate).ToList();
//            return View(list);
//        }

//        public ActionResult Index()
//        {
//            if (Session["LoginUserSessionModel"] == null)
//                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
//            var list = _context.Genres.OrderByDescending(x => x.Name).ToList();
//            var list1 = _context.Albuns.OrderByDescending(x => x.PublsherDate).ToList();

//            return View(list);

//        }

//        [HttpPost]
//        [ValidateInput(false)]
//        public ActionResult Reply(Guid id,string content,string title,string Replyid)
//      {

//            if (Session["LoginUserSessionModel"] == null)
//                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
//            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
//            Reply parentReply = null; 
//            if (title == "回复")
//                parentReply = _context.Replys.Find(Guid.Parse(Replyid));
//            var reply = new Reply()
//            {
//                Title = title,
//                Content = content,
//                Album = _context.Albuns.Find(id),
//                 Person = person,
//                 ParentReply = parentReply
//            };


//            //reply.ParentReply = reply;
//          _context.Replys.Add(reply);
//            _context.SaveChanges();
//            var list  = new  List<Reply>();//评论
//            var list1 = new List<Reply>();//回复评论
//            try { list = _context.Replys.Where(x => x.Album.ID == id && x.Title == "评论").OrderBy(x => x.CreateDateTime).ToList(); }
//            catch { }
//            try { list1 = _context.Replys.Where(x => x.Album.ID == id && x.Title == "回复").OrderBy(x => x.CreateDateTime).ToList(); }
//            catch { }
//            var htmlString = "";
//            foreach (var item in list)
//            {
//                htmlString+= "<li class=\"comments_item\">";
//                htmlString += " <div class=\"comments_item_bd\">";
//                htmlString += " <img class=\"replyImg\" src=" + item.Person.Avarda+">";
//                    htmlString += "<span>" + item.Person.Name+ " " + item.Title + "</span>";
//                htmlString += " <span>" + item.Content + "</span>";
//                htmlString += "<p>" + item.CreateDateTime + "</p>";

//                htmlString += "<a href=\"javascript:; \"  id="+item.ID+" >回复</a>";

//                htmlString += "</div>";
//                htmlString += "<div class=\"mod_comments_sub\">";
//                htmlString += "<ol>";
//                foreach (var rtem in list1)
//                    {

//                    if (item.ID == rtem.ParentReply.ID)
//                    {

//                        htmlString += "<li class=\"comments_item_ol_li\">";

//                        htmlString +="<img class=\"replyImg\" src="+rtem.Person.Avarda+">";
//                        htmlString += "<span> "+rtem.Person.Name+" "+rtem.Title+" "+rtem.ParentReply.Person.Name+"</span>";
//                        htmlString += "<span> "+rtem.Content+"</span>";
//                        htmlString += "<p> "+rtem.CreateDateTime+"</p>";
//                        htmlString +="<a href = \"javascript:;\" id= "+item.ID+" > 回复 </a>";

//                        htmlString += "</li>";


//                        }


//                }
//                htmlString += "</ol>";
//                htmlString += "</div>";
//                htmlString += "</li>";
//            }

//            return Json(htmlString);
//        }

//    }
//}