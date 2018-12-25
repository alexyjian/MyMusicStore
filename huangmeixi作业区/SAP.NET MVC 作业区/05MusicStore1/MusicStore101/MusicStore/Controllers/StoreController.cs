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
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Store
        public ActionResult Detail(Guid id)
        {
            var detail = _context.Albums.Find(id);
            return View(detail);
        }



        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Content(string str, Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            if (str == "")
                return Json("");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            var album = _context.Albums.Find(id);

            //添加评论
            var txt = new Reply()
            {
                Title = str,
                Person = _context.Persons.Find(person,id).Name,
                Content = str,
                Album = album,
            };
            _context.Replys.Add(txt);
            _context.SaveChanges();


            // 显示评论
            var albumSay = _context.Albums.Find(id).Reply.OrderByDescending(x => x.CreateDateTime).ToList();
            var htmlString = "";

            foreach (var item in albumSay)
            {
                htmlString += "<p>" + item.Person + ":" + item.Content + "<br/>";
                htmlString += "<em>" + item.CreateDateTime + "</em></p>";

            }
            return Json(htmlString);
 
        }



  
        /// <summary>
        /// 按分类显示专辑页
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
            var genres = _context.Genres.OrderBy(x=>x.Name).ToList();
            return View(genres);
        }
    }
}