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
        private static readonly MusicContext _context = new MusicContext();
        // GET: Store
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View(detail);
        }
        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x=>x.Genre.ID==id).OrderByDescending(x=>x.PublisherDate).ToList();
            return View(list);
        }
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(x
                  => x.Name).ToList();
            return View(genres);
        }
        [HttpPost]
        [ValidateInput(false)]
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
                //顶级回复,parentReply为空
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Replies.Find(Guid.Parse(reply));
            }
            
            return Json("OK");
        }
        
    }
}