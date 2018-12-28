
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
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(string id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
            var ID = Guid.Parse(id);
            var detail = _context.Albuns.Find(ID);
          
            ViewBag.detail = detail;
            //var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var Cmt = _context.Replys.Where(x => x.Album.ID == ID && x.ParentReply==null).OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.Cmt = _GetHtml(Cmt);
            return View();
        }
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
                htmlString += "<div class='media-body' id='cen_"+item.ID+"'>";
                htmlString += "<h5 class='media-heading'>" + item.Person.Name + "  发表于" +
                              item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                //查询当前回复的下一级回复
                var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6><a href='javascript:;' onclick='hide(\"" + item.ID+"\")' class='reply'>回复</a>(" + sonCmt.Count + ")条" + "  <a href='javascript:;'><i class='glyphicon glyphicon-thumbs-up'></i></a>(" +
                              item.Like + ")  <a href='javascript:;'><i class='glyphicon glyphicon-thumbs-down'></i></a>(" + item.Hate + ")</h6>";
                
                //乱来
                htmlString += "<div class='row bb' id='"+ item.ID+"' style='display: none;'>";
                htmlString += "<div class='col-md-10'>";
                htmlString += "<div class='form -group'>";
                htmlString += "<textarea id ='editor' name='editor'></textarea>";
                htmlString += "<button id='btnCmt' type='button' class='btn btn-success'>评论</button>";
                htmlString += " </div>";
               
                htmlString += "</div>";
                htmlString += "</div>";
            //乱来结束
            htmlString += "<ol class='media-list'>";
              
                foreach (var sonitem in sonCmt)
                {
                    htmlString += "<li class='media'>";
                    htmlString += "<div class='media-left'>";
                    htmlString += "<img class='media-object' src='" + sonitem.Person.Avarda +
                                  "' alt='头像' style='width:40px;border-radius:50%;'>";
                    htmlString += "</div>";
                    htmlString += "<div class='media-body'>";
                    htmlString += "<h5 class='media-heading'>" + sonitem.Person.Name + "回复 "+ sonitem .ParentReply.Person.Name+ "" +
                                  sonitem.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                    htmlString += sonitem.Content;
                    htmlString += "</div>";
                    htmlString += "<a href='javascript:;' onclick='hide(\"" + sonitem.ID + "\")' class='reply'>回复</a>";

                    //乱来
                    htmlString += "<div class='row bb' id='"+ sonitem.ID + "' style='display: none;'>";
                    htmlString += "<div class='col-md-10'>";
                    htmlString += "<div class='form -group'>";
                    htmlString += "<textarea id ='editor' name='editor'></textarea>";
                    htmlString += "<button id='btnCmt' type='button' class='btn btn-success'>评论</button>";
                    htmlString += " </div>";
                   
                    htmlString += "</div>";
                    htmlString += "</div>";
                    //乱来结束
                }

                htmlString += "</ol>";

                htmlString += "</li>";
            }
            htmlString += "</ul>";
          
            return htmlString;
        }

        //
        public ActionResult browser(Guid id)
        {
            var list = _context.Albuns.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublsherDate).ToList();
            return View(list);
        }

        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
            var list = _context.Genres.OrderByDescending(x => x.Name).ToList();
            var list1 = _context.Albuns.OrderByDescending(x => x.PublsherDate).ToList();

            return View(list);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCmt(string id, string cmt, string reply)
        {

            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var album = _context.Albuns.Find(Guid.Parse(id));

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
              var   replyID = Guid.Parse(reply);
                r.ParentReply = _context.Replys.Find(replyID);
            }

            var Id = Guid.Parse(id);


            _context.Replys.Add(r);
            _context.SaveChanges();
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