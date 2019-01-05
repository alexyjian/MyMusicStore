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
        /// 点赞
        /// </summary>
        /// <param name="id">回复的id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Like(string id, string Albumid)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var ID = Guid.Parse(id); //把传过来的ID转换成GUID
            var AblumID = Guid.Parse(Albumid);

            //判断用户是否对这条回复点过赞或踩
            var person = _Context.Persons.Find((Session["LoginUserSessionModel"]
                as LoginUserSessionModel).Person.ID);

            var sonCmt = _Context.LikeReplies.Where(x => x.Person.ID == person.ID && x.Reply.ID == ID).ToList();
            var reply = _Context.Replys.Find(ID);
            //保存 reply实体中like+1或hate+1 LikeReply添加一条记录
            if (sonCmt.Count == 0)
            {
                reply.Like +=1;

                var like = new LikeReply()
                {
                    IsNoLike = true,
                    Reply = reply,
                    Person = person,
                };

                _Context.LikeReplies.Add(like);
                _Context.SaveChanges();

                //局部刷新显示成最新的评论
                var cmt = _Context.Replys.Where(x => x.Ablum.ID == AblumID && x.ParentReply == null)
                    .OrderByDescending(x => x.CreateDateTime).ToList();
                return Json(_GetHtml(cmt));
        }

        //生成HTML注入
        var cmt1 = _Context.Replys.Where(x => x.Ablum.ID == AblumID && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            return Json(_GetHtml(cmt1));

        }

        /// <summary>
        /// 踩
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Hate(string id, string AblumID)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            var ID = Guid.Parse(id); //把传过来的ID转换成GUID
            var Albumid = Guid.Parse(AblumID);

            var person = _Context.Persons.Find((Session["LoginUserSessionModel"]
                as LoginUserSessionModel).Person.ID);

            var hate = _Context.Replys.Find(ID);
            var sonCmt = _Context.LikeReplies.Where(x => x.Person.ID == person.ID && x.Reply.ID == ID).ToList();
            if (sonCmt.Count == 0)
            {
                hate.Hate += 1;

                var hate1 = new LikeReply()
                {
                    IsNoLike = false,
                    Reply = hate,
                    Person = person,

                };
                _Context.LikeReplies.Add(hate1);
                _Context.SaveChanges();


                //局部刷新显示成最新的评论
                var cmt = _Context.Replys.Where(x => x.Ablum.ID == Albumid && x.ParentReply == null)
                    .OrderByDescending(x => x.CreateDateTime).ToList();
                return Json(_GetHtml(cmt));
            }

            //生成HTML注入
            var cmt1 = _Context.Replys.Where(x => x.Ablum.ID == ID && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            return Json(_GetHtml(cmt1));

        }

        /// <summary>
        /// 生成回复的显示HTML文本
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        private string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            htmlString += "<ul class='media-list'>";
            foreach (var item in cmt)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString+= "<img class='media-object'src='"+item.Person.Avarda+"'alt='头像'style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString+= "<div class='media-body' id='Content-"+item.ID+"'>";
                htmlString += "<h5 class='media-heading'><em>"+item.Person.Name+ "</em>&nbsp;&nbsp;发表于" + item.CreateDateTime.ToString("yyy年MM月dd日 hh点mm分ss秒")+ "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";

                //查询当前回复的下一级回复
                var sonCmt = _Context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();              
                htmlString += "<h6><a href='#div-editor' onclick=\"javascript:GetQuote('"+item.ID+ "','"+item.ID+"');\">回复</a>(<a href='javascript:;'class='reply'onclick=\"javascript:ShowCmt('"+item.ID+"');\">"+sonCmt.Count+"</a>)条"+
                              "<a href='javascript:;'style='margin:0 20px 0 50px' onclick=\"javascript:Like('" + item.ID + "')\"><i class='glyphicon glyphicon-thumbs-up'></i>(" + item.Like+ ")</a>" +
                              "<a href='javascript:;'style='margin:0 20px' onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate+")</a></h6>";

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

     
        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult showCmts(string pid)
        {
            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _Context.Replys.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime).ToList();

            //原回复
            var pcmt = _Context.Replys.Find(id);
            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">x</button> ";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主：&nbsp;&nbsp;</em>" + pcmt.Person.Name + "&nbsp;&nbsp;发表于" +
                          pcmt.CreateDateTime.ToString("yyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += "</h4> </div>";

            htmlString += " <div class=\"modal-body\">";

            //找出子回复
            //var sonCmt = _Context.Replys.Where(x => x.ParentReply.ID == id).ToList();

            //子回复
            htmlString += "<ul class='media-list' style='margin-left:20px;' style = 'border: 1px solid #f08080'>";
            //循环子回复
            foreach (var item in cmts) 
            {
                htmlString += "<li class='media'style = 'border: 1px solid #f08080' >";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'><em>" + pcmt.Person.Name + "</em>&nbsp;&nbsp;发表于" +
                              pcmt.CreateDateTime.ToString("yyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                htmlString += "<h6><a href='#div-editor' onclick=\"javascript:GetQuote('" +item.ParentReply.ID+"','"+item.ID + "');\">回复</a> "+
                              "<a href='javascript:;'style='margin:0 20px 0 50px' onclick=\"javascript:Like('" + item.ID + "')\"><i class='glyphicon glyphicon-thumbs-up'></i>(" + item.Like + ")</a>" +
                              "<a href='javascript:;'style='margin:0 20px' onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";

                htmlString += "</li>";
            }
            htmlString += "</ul>";
            htmlString += "<div class='modal-footer'>";
            htmlString += "</div>";
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
    }
}