using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;
using Music.ViewModels;

namespace Music.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Store
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            var reply = _context.Replys.Where(x => x.Album.ID == detail.ID).Where(x=>x.ID==x.ParentReply.ID).OrderByDescending(x=>x.CreateDateTime).ToList();
            var htmlString = "";
            foreach (var item in reply)
            {
                htmlString += "<div id='pinl_main'>";
                htmlString += "<div id='pinl_main_main'>";
                htmlString += "<div>";
                htmlString += "<img src=" + item.Person.Avarda + ">";
                htmlString += "</div>";
                htmlString += "<div>";
                htmlString += "<p>" + item.Title + "</p>";
                htmlString += "<p>" + item.Content + "</p>";
                htmlString += "</div>";
                htmlString += "<div>";
                htmlString += "<ul id='"+item.ID+"'>";
                htmlString += "<li></li>";
                htmlString += "<li>"+item.CreateDateTime+"</li>";
                htmlString += "<li onmouseover='on(this)' onmouseout='out(this)' onclick='ADD(this)'>回复</li>";
                htmlString += "</ul>";
                htmlString += "</div>";
                htmlString += "</div>";
                htmlString += "<hr>";
                htmlString += "</div>";
            }
            var cartVM = new DetailReply()
            {
                ID = detail.ID,
                Title = detail.Title,
                Price =detail.Price,
                PublisherDate = detail.PublisherDate,
                AlbumArtUrl = detail.AlbumArtUrl,
                Genre=detail.Genre,
                Artist=detail.Artist,
                MusicUrl = detail.MusicUrl,
                Replys = htmlString
            };
            return View(cartVM);
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
            var genres = _context.Genres.OrderBy(x=>x.Name).ToList();

            return View(genres);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Reply(Guid id,Guid replyID, string content,string contentreply,string contentreplys)
         {
            //判断用户是否登陆
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
            }
            //查询出当前登陆用户
            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;

            var replys= new Reply()
            {
                Title=person.Name,
              
                Person=_context.Persons.Find(person.ID),
                Album=_context.Albums.Find(id)
            };
            if (contentreply != null)
            {
                replys.Content = contentreply;
                replys.ParentReply = _context.Replys.Find(replyID);
                replys.ParentReplySub = replys;
            }
            else if (contentreplys!=null)
            {

            }
            else
            {
                replys.Content = content;
                replys.ParentReply = replys;
                replys.ParentReplySub = replys;
            }            
            _context.Replys.Add(replys);
            _context.SaveChanges();
            var reps = _context.Replys.Where(x=>x.Album.ID==id).OrderByDescending(x => x.CreateDateTime);
            var htmlString = "";
            foreach (var item in reps)
            {
                htmlString += "<div id='pinl_main_main'>";
                htmlString += "<div>";
                htmlString += "<img src=" + item.Person.Avarda + ">";
                htmlString += "</div>";
                htmlString += "<div>";
                htmlString += "<p>" + item.Title + "</p>";
                htmlString += "<p>" + item.Content + "</p>";
                htmlString += "</div>";
                htmlString += "<div>";
                htmlString += "<ul>";
                htmlString += "<li></li>";
                htmlString += "<li>" + item.CreateDateTime + "</li>";
                htmlString += "<li>回复</li>";
                htmlString += "</ul>";
                htmlString += "</div>";
                htmlString += "</div>";
            }
            return Json(htmlString);
        }
    }
}