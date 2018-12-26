using MusicStore.ViewModels;
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
        [HttpPost]
        [ValidateInput(false )] //关闭验证
        public ActionResult AddCmt(string id,string cmt,string  reply)
        {

            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
          LoginUserSessionModel).Person.ID);
            var alnum = _context.Albums.Find(Guid.Parse(id));

            //创建回复对象
            var r = new Reply()
            {
                Album = alnum,
                Person =person,
                Content=cmt,
            };
            //父级回复
            if(string .IsNullOrEmpty(reply))
            {
                //顶级回复
                r.ParentReoly = null;
            }
            else
            {
                r.ParentReoly = _context.Replies.Find(Guid.Parse(reply));
            }
            _context.Replies.Add(r);
            _context.SaveChanges();
            return Json("OK");

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
            var genres = _context.Genres.OrderBy(x => x.Name).ToList();
            return View(genres);
        }
    }
}