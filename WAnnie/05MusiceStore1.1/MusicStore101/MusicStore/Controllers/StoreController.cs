using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public static readonly MusicContext _Context=new MusicContext();
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
           
            var detail = _Context.Ablums.Find(id);
            var cmt = _Context.Replys.Where(x => x.Ablum.ID == id && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();

            ViewBag.Cmt = _GetHtml(cmt);
            return View(detail);
      
        }

        /// <summary>
        /// 生成回复的显示HTML文本
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        private string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media - list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString+= "<img class='media-object'src='"+item.Person.Avarda+"'alt='头像'style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString+= "<div class='media-body' id='Content-"+item.ID+"'>";
                htmlString += "<h5 class='media-heading'>"+item.Person.Name+"发表于"+item.CreateDateTime.ToString("yyy年MM月dd日 hh点mm分ss秒")+ "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";

                //查询当前回复的下一级回复
                var sonCmt = _Context.Replys.Where(x => x.Person.ID == item.ID).ToList();              
                htmlString += "<h6><a></a href='#div-editor'class='reply' onclick=\"javascript:GetQuote('"+item.ID+
                              "');\">回复</a>(<a href='#'class='reply'onclick=\"javascript:ShowCmt('"+item.ID+"');\">"+sonCmt.Count+"</a>)条"+
                              "<a href='#'class='reply'style='margin:0 20px 0 50px'><i class='glyphicon glyphicon-thumbs-up'></i>("+
                              item.Like+ ")</a><a href='#'class='reply'style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>("+item.Hate+")</a></h6>";

                htmlString += "</li>";
            }

            htmlString += "</ul>";
            return htmlString;
        }

        [HttpPost]
        [ValidateInput(false)] //关闭验证       
        public ActionResult AddCmt(string cmt, string reply,string id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _Context.Persons.Find((Session["LoginUserSessionModel"] 
                as LoginUserSessionModel).Person.ID);
            var ablum = _Context.Ablums.Find(Guid.Parse(id));

            //创建回复
            var r = new Reply()
            {
                Ablum = ablum,
                Person = person,
                Content = cmt,
                Title = ""
            };
            //父级回复
            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复,ParentReply为空
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _Context.Replys.Find(Guid.Parse(reply));
            }

            _Context.Replys.Add(r);
            _Context.SaveChanges();

            //局部刷新显示成最新的评论
            var replies = _Context.Replys.Where(x => x.Ablum.ID == ablum.ID && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            return Json(_GetHtml(replies));
        }


        [HttpPost]
        public ActionResult showCmts(string pid)
        {
            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _Context.Replys.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime) .ToList();

            //原回复
            var pcmt = _Context.Replys.Find(id);
            htmlString += "<div class=\"modal - header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">x</button> ";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主</em>" + pcmt.Person.Name + "发表于" +
                          pcmt.CreateDateTime.ToString("yyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += "</h4> </div>";

            htmlString += " <div class=\"modal-body\">";
            //子回复
            htmlString += " <div class=\"modal-footer\"></ div >";
            return Json(htmlString);
        }

        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _Context.Ablums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }
        /// <summary>
        /// 显示所有的分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var genres = _Context.Genres.OrderBy(x => x.Name).ToList();
            return View(genres);
        }



        //public ActionResult Detail(Guid id)
        //{

        //    var detail = _Context.Ablums.Find(id);
        //    var cmt = _Context.Replys.Where(x => x.Ablum.ID == id && x.ParentReply == null)
        //        .OrderByDescending(x => x.CreateDateTime).ToList();

        //    ViewBag.Cmt = _GetHtml(cmt);
        //    return View(detail);

        //    if (Session["LoginUserSessionModel"] == null)
        //        return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Store") });
        //    var person = _Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
        //    try
        //    {
        //        ViewBag.Reply = _Context.Replys.Where(x => x.Ablum.ID == id && x.Person.ID == person.ID).ToList();
        //    }
        //    catch
        //    {

        //    }
        //    return View(detail);

        //}
        //[HttpPost]
        //public ActionResult Reply(Guid id, string pary)
        //{
        //    if (Session["LoginUserSessionModel"] == null)
        //        return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
        //    var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

        //    var rely = new Reply()
        //    {
        //        Content = pary,
        //        Ablum = _Context.Ablums.Find(id),
        //        Person = _Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID),

        //    };
        //    _Context.Replys.Add(rely);
        //    _Context.SaveChanges();
        //    var list=new List<Reply>();
        //    var p = _Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
        //    try
        //    {
        //        list = _Context.Replys.Where(x => x.Ablum.ID == id && x.Person.ID == person.ID).ToList();
        //    }
        //    catch 
        //    {

        //    }
        //    var htmlString = "";
        //    foreach (var item in list)
        //    {
        //        htmlString += "<div class=\"pary\">";
        //        htmlString += "<img style=\"width: 80px; border-radius: 50%;\" src="+item.Person.Avarda+">";
        //        htmlString += "<p>"+item.Person.Name+"</p>";
        //        htmlString += "<p>"+item.CreateDateTime+"</p>";
        //        htmlString += "<p>"+item.Content+"</p>";
        //        htmlString += "</div>";

        //    }

        //    return Json(htmlString);
        //}
    }
}