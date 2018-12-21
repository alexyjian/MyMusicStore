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
        private static readonly EntityDbContext _context = new EntityDbContext();
        /// <summary>
        /// 显示专辑明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detai(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View(detail);
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
        public ActionResult Comments()
        {
            
          
            //获取当前用户ID
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var Commentss = _context.Commentss.Where(x => x.Person.ID == x.Person.ID).ToList();
         
            return View(Commentss);
        }
        [HttpPost]
        public ActionResult Commentsadd(Guid id)
        {
            //判断是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });
            //获取当前用户ID
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

           
            var Comments = _context.Commentss.SingleOrDefault(x => x.Person.ID == x.Person.ID && x.Album.ID == id);
            Comments = new Comments() {
                Album = _context.Albums.Find(id),
                Person = _context.Persons.Find(person.ID),
                content = "11111111aaaaaaaa",
            };
            _context.Commentss.Add(Comments);
            _context.SaveChanges();
            
            return Content("< script > alert('评论成功!') </ script >");
        }

    }
}