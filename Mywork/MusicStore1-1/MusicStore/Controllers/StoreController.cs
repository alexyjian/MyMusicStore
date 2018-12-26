using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
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
        /// 按分类显示专辑
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCmt(string id,string cmt,string reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
                Person).ID);
            var album = _context.Albums.Find(Guid.Parse(id));

            //创建对象
            var r = new Reply()
            {
                Album = album,
                Person = person,
                Content = cmt,
                Title=""
            };
            //父级回复
            if(string.IsNullOrEmpty(reply))
            {
                //顶级回复
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Reoly.Find(Guid.Parse(reply));
            }
            _context.Reoly.Add(r);
            _context.SaveChanges();
            return Json("OK");
        }

        /// <summary>
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            var genre = _context.Genres.OrderBy(x => x.Name).ToList();
            return View(genre);
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ActionResult Commit(string content)
        {
            return View();
        }

    }
}