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
            var cmt = _context.Replies.Where(x => x.Album.ID == id && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);


            return View(detail);
        }
        private string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
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
                var sonCmt = _context.Replies.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<h6><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ID +
                              "');\">回复</a>(<a href='#' class='reply'  onclick=\"javascript:ShowCmt('" + item.ID + "');\">" + sonCmt.Count + "</a>)条" +
                              "<a href='#' class='reply' style='margin:0 20px 0 40px'><i class='glyphicon glyphicon-thumbs-up'></i>(" +
                              item.Like + ")</a><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";

                htmlString += "</li>";
            }
            htmlString += "</ul>";
            return htmlString;
        }
        [HttpPost]
        public ActionResult showCmts(string pid)
        {
            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _context.Replies.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime).ToList();
            //原回复
            var pcmt = _context.Replies.Find(id);
            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主</em>" + pcmt.Person.Name + "  发表于" + pcmt.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += " </h4> </div>";

            htmlString += "<div class=\"modal-body\">";
            //子回复
            htmlString += "</div><div class=\"modal-footer\"></div>";
            return Json(htmlString);
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
            _context.Replies.Add(r);
            _context.SaveChanges();
            return Json("OK");
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <returns name="id">回复id</returns>
        [HttpPost]
        public ActionResult Like()
        {
            //1.判断用户是否登录

            //2.判断

            //3.保存 reply 实体中like+1或hate+1 LikeReply添加一条记录

            //生成html注入视图
            return View();
        }
        
    }
}