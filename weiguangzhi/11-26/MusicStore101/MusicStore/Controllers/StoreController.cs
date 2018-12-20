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

        public ActionResult Browser(Guid id)
        {
            var list = _context.Albums.Where(x => x.Genre.ID == id).OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(x => x.Name).ToList();
            return View(genres);
        }

        [HttpPost]
        public ActionResult RemoveDetail(Guid id)
        {
            //如果会话为空，则重新刷新页面
            if (Session["Album"] == null)
                return RedirectToAction("detail");

            //读取会话中的Order对象
            var order = Session["Album"] as Album;

            //读取会话中的Order对象
            Session["Order"] = order;
            var htmlString = "";
            foreach (var item in order.Replys)
            {

                htmlString +="<p>"+ @item.Person.LastName+"</p>";
                htmlString += "<p>" + "内容:" + @item.Content + "</p>";
                htmlString += "<p>" + "标题" + @item.CreateDateTime + "</p>";
                htmlString += "<hr />";
            }

          

            return Json(htmlString);

        }
        [HttpPost]
        public ActionResult HuiFui(Guid id)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });
            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

           

            return View();
        }
        }
}