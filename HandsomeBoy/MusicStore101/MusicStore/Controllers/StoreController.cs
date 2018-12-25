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
        public ActionResult Detail(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
            var detail = _context.Albuns.Find(id);
            ViewBag.detail = detail;
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            try { ViewBag.Reply = _context.Replys.Where(x => x.Album.ID == id&&x.Title=="评论").OrderBy(x=>x.CreateDateTime).ToList(); }
            catch { }
            try { ViewBag.ParentReply = _context.Replys.Where(x => x.Album.ID == id&&x.Title=="回复").OrderBy(x => x.CreateDateTime).ToList(); }
            catch { }
         
            return View();
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
        public ActionResult Reply(Guid id,string content,string title,string Replyid)
      {
           
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Login") });
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            Reply parentReply = null; 
            if (title == "回复")
                parentReply = _context.Replys.Find(Guid.Parse(Replyid));
            var reply = new Reply()
            {
                Title = title,
                Content = content,
                Album = _context.Albuns.Find(id),
                 Person = person,
                 ParentReply = parentReply
            };
           
              
            //reply.ParentReply = reply;
          _context.Replys.Add(reply);
            _context.SaveChanges();
            var list  = new  List<Reply>();//评论
            var list1 = new List<Reply>();//回复评论
            try { list = _context.Replys.Where(x => x.Album.ID == id).OrderBy(x => x.CreateDateTime).ToList(); }
            catch { }
            try { list1 = _context.Replys.Where(x => x.Album.ID == id && x.Title == "回复").OrderBy(x => x.CreateDateTime).ToList(); }
            catch { }
            var htmlString = "";
            foreach (var item in list)
            {
                htmlString+= "<li class=\"comments_item\">";
                htmlString += " <div class=\"comments_item_bd\">";
                htmlString += " <img class=\"replyImg\" src=" + item.Person.Avarda+">";
                    htmlString += "<span>" + item.Person.Name+ " " + item.Title + "</span>";
                htmlString += " <span>" + item.Content + "</span>";
                htmlString += "<p>" + item.CreateDateTime + "</p>";
               
                htmlString += "<a href=\"javascript:; \"  id="+item.ID+" >回复</a>";

                htmlString += "</div>";
                htmlString += "<div class=\"mod_comments_sub\">";
                htmlString += "<ol>";
                foreach (var rtem in list1)
                    {
                  
                    if (item.ID == rtem.ParentReply.ID)
                    {
                       
                        htmlString += "<li>";
                    
                        htmlString +="<img class=\"replyImg\" src="+rtem.Person.Avarda+">";
                        htmlString += "<span> "+rtem.Person.Name+" "+rtem.Title+" "+rtem.ParentReply.Person.Name+"</span>";
                        htmlString += "<span> "+rtem.Content+"</span>";
                        htmlString += "<p> "+rtem.CreateDateTime+"</p>";
                        htmlString +="<a href = \"javascript:;\" id= "+item.ID+" > 回复 </a>";
                      
                        htmlString += "</li>";
                        

                        }
                  

                }
                htmlString += "</ol>";
                htmlString += "</div>";
                htmlString += "</li>";
            }
           
            return Json(htmlString);
        }

    }
}