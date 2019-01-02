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
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Store
        public ActionResult Detail(Guid id)
        {


            var detail = _context.Albums.Find(id);
            var cmt = _context.Replys.Where(x => x.Album.ID == id && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            ViewBag.Cmt = _GetHtml(cmt);
            return View(detail);


        }

        [HttpPost]
        public ActionResult Detail(RepViewModel model)
        {
            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "ShonppingCart") });
            //查询出当前登录用户
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            if (ModelState.IsValid)
            {
                var rep = new Reply()
                {
                    Content = model.Content,
                    Person = model.Person,
                    Album = model.Album,
                    CreateDateTime = DateTime.Now,
                };
                _context.SaveChanges();
            }


            return View();
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

        //[HttpPost]
        //public ActionResult RemoveDetail(Guid id, string content)
        //{
        //    //判断用户是否登陆
        //    if (Session["loginUserSessionModel"] == null)
        //    {
        //        return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
        //    }
        //    //查询出当前登陆用户
        //    var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;

        //    var replys = new Reply()
        //    {

        //        Content = content,
        //        Person = _context.Persons.Find(person.ID),
        //        Album = _context.Albums.Find(id)
        //    };

        //    _context.Replys.Add(replys);
        //    _context.SaveChanges();
        //    var reps = _context.Replys.Where(x => x.Album.ID == id).OrderByDescending(x => x.CreateDateTime);
        //    var htmlString = "";
        //    foreach (var item in reps)
        //    {
        //        htmlString += "<div id='demo' class='table - responsive collapse'>";
        //        htmlString += "<table class='table table-hover '>";
        //        htmlString += "<tbody>";
        //        htmlString += "<tr>";

        //        htmlString += "<td>" + "<img src = " + @item.Person.Avarda + "/>" + @item.Person.LastName + "</td>";
        //        htmlString += item.Content;
        //        htmlString += "<td>" + @item.CreateDateTime + "</td>";
        //        htmlString += "<a href=\"javascript:; \" >回复</a>";
        //        htmlString += "</tr>";
        //        htmlString += "</tbody>";
        //        htmlString += "</table>";
        //        htmlString += "</div>";
        //    }

        //    return Json(htmlString);


        //}



        [HttpPost]
        [ValidateInput(false)]//关闭验证
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
                //顶级回复, ParentReply为空
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Replys.Find(Guid.Parse(reply));
            }

            _context.Replys.Add(r);
            _context.SaveChanges();

            //局部刷新显示成最新的评论
            var replies = _context.Replys.Where(x => x.Album.ID == album.ID && x.ParentReply == null)
                .OrderByDescending(x => x.CreateDateTime).ToList();
            return Json(_GetHtml(replies));

        }

        [HttpPost]
        public ActionResult showCmts(string pid)
        {
            var htmlString = "";
            //子回复
            Guid id = Guid.Parse(pid);
            var cmts = _context.Replys.Where(x => x.ParentReply.ID == id).OrderByDescending(x => x.CreateDateTime).ToList();
            //原回复
            var pcmt = _context.Replys.Find(id);
            htmlString += "<div class=\"modal-header\">";
            htmlString += "<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>";
            htmlString += "<h4 class=\"modal-title\" id=\"myModalLabel\">";
            htmlString += "<em>楼主&nbsp;&nbsp;</em>" + pcmt.Person.Name + "&nbsp;&nbsp;发表于" + pcmt.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + ":<br/>" + pcmt.Content;
            htmlString += " </h4> </div>";

            htmlString += "<div class=\"modal-body\">";
            //子回复
            htmlString += "<ul class='media-list' style='margin-left:20px;'>";
            foreach (var item in cmts)
            {
                htmlString += "<li class='media'>";
                htmlString += "<div class='media-left'>";
                htmlString += "<img class='media-object' src='" + item.Person.Avarda +
                              "' alt='头像' style='width:40px;border-radius:50%;'>";
                htmlString += "</div>";
                htmlString += "<div class='media-body' id='Content-" + item.ID + "'>";
                htmlString += "<h5 class='media-heading'><em>" + item.Person.Name + "</em>&nbsp;&nbsp;发表于" +
                              item.CreateDateTime.ToString("yyyy年MM月dd日 hh点mm分ss秒") + "</h5>";
                htmlString += item.Content;
                htmlString += "</div>";
                htmlString += "<h6><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ParentReply.ID + "','" + item.ID + "');\">回复</a>" +
                              "<a href='#' class='reply' style='margin:0 20px 0 40px'   onclick=\"javascript:Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up'></i>(" + item.Like + ")</a>" +
                              "<a href='#' class='reply' style='margin:0 20px'   onclick=\"javascript:Hate('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></h6>";
                htmlString += "</li>";
            }
            htmlString += "</ul>";
            htmlString += "</div><div class=\"modal-footer\"></div>";
            return Json(htmlString);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmt"></param>
        /// <returns></returns>
        private string _GetHtml(List<Reply> cmt)
        {
            var htmlString = "";
            htmlString += "<button type = 'button' class='btn btn-primary' data-toggle='collapse'data-target='#demo'>收起评论</button>";
            htmlString += "<div id = 'demo' class='table - responsive collapse in'>";
            htmlString += "<table class='table table-hover '>";
        htmlString += "<thead>";
        htmlString += "<tr>";
        htmlString += "<th>用户</th>";
        htmlString += "<th>评论内容</th>";
        htmlString += "<th>赞</th>";
        htmlString += "<th>踩</th>";
        htmlString += "<th>评论时间</th>";
        htmlString += "<th>回复</th>";
        htmlString += "</tr>";
        htmlString += "</thead>";
        htmlString += "<tbody>";
            foreach (var item in cmt)
            {
            htmlString += "<tr>";
            htmlString += "<td><a><img src ='"+@item.Person.Avarda+"'style = 'width: 35px; height: 35px;'/> &nbsp;"+ @item.Person.LastName+"</a></td>";
            htmlString += "<td>"+@item.Content+"</td>";
            htmlString += "<td><a href='#' class='reply' style='margin:0 20px'onclick=\"Like('" + item.ID + "');\"><i class='glyphicon glyphicon-thumbs-up' ></i>(" + item.Like + ")</a></td>";
            htmlString += "<td><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></td>";
            htmlString += "<td>"+@item.CreateDateTime+"</td>";
            var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
            htmlString += "<td><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ID + "');\">回复</a>(<a href='#' class='reply'  onclick=\"javascript:ShowCmt('" + item.ID + "');\">" + sonCmt.Count + "</a>)条</td>";
            htmlString += "</tr>";


            }
            htmlString += "</tbody>";
            htmlString += "</table>";
            htmlString += "</div>";
            htmlString += "</div>";
            return htmlString;
        }

        [HttpPost]
        public ActionResult Hate(string id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
                LoginUserSessionModel).Person.ID);
            var like = _context.Replys.Find(Guid.Parse(id));
            if (like.Hate >= 0)
            {
                like.Hate++;
                var l = new LikeReply()
                {
                    Reply = like,
                    Person = person,
                    CreateDateTime = DateTime.Now,
                    IsNotLike = false,
                };

                _context.LikeReply.Add(l);
                _context.SaveChanges();

            }


            var likes = _context.Replys.Where(x => x.Person.ID == person.ID).ToList();
            var htmlString = "";
            htmlString += "<button type = 'button' class='btn btn-primary' data-toggle='collapse'data-target='#demo'>收起评论</button>";
            htmlString += "<div id = 'demo' class='table - responsive collapse in'>";
            htmlString += "<table class='table table-hover '>";
            htmlString += "<thead>";
            htmlString += "<tr>";
            htmlString += "<th>用户</th>";
            htmlString += "<th>评论内容</th>";
            htmlString += "<th>赞</th>";
            htmlString += "<th>踩</th>";
            htmlString += "<th>评论时间</th>";
            htmlString += "<th>回复</th>";
            htmlString += "</tr>";
            htmlString += "</thead>";
            htmlString += "<tbody>";
            foreach (Reply item in likes)
            {
                htmlString += "<tr>";
                htmlString += "<td><a><img src ='" + @item.Person.Avarda + "'style = 'width: 35px; height: 35px;'/> &nbsp;" + @item.Person.LastName + "</a></td>";
                htmlString += "<td>" + @item.Content + "</td>";
                htmlString += "<td><a href='#' class='reply' style='margin:0 20px'onclick=\"Like('ss');\"><i class='glyphicon glyphicon-thumbs-up' ></i>(" + item.Like + ")</a></td>";
                htmlString += "<td><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></td>";
                htmlString += "<td>" + @item.CreateDateTime + "</td>";
                var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<td><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ID + "');\">回复</a>(<a href='#' class='reply'  onclick=\"javascript:ShowCmt('" + item.ID + "');\">" + sonCmt.Count + "</a>)条</td>";
                htmlString += "</tr>";
            }
            htmlString += "</tbody>";
            htmlString += "</table>";
            htmlString += "</div>";
            htmlString += "</div>";
            return Json(htmlString);



        }
 

        [HttpPost]
        public ActionResult Like(string id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as
                LoginUserSessionModel).Person.ID);

            var like = _context.Replys.Find(Guid.Parse(id));
            if (like.Like >= 0)
            { 
                like.Like++;
                var l = new LikeReply()
                {
                    Reply = like,
                    Person = person,
                    CreateDateTime = DateTime.Now,
                    IsNotLike = true,
                };

                _context.LikeReply.Add(l);
                _context.SaveChanges();

            }


            var likes =_context.Replys.Where(x => x.Person.ID == person.ID).ToList();
            var htmlString = "";
            htmlString += "<button type = 'button' class='btn btn-primary' data-toggle='collapse'data-target='#demo'>收起评论</button>";
            htmlString += "<div id = 'demo' class='table - responsive collapse in'>";
            htmlString += "<table class='table table-hover '>";
            htmlString += "<thead>";
            htmlString += "<tr>";
            htmlString += "<th>用户</th>";
            htmlString += "<th>评论内容</th>";
            htmlString += "<th>赞</th>";
            htmlString += "<th>踩</th>";
            htmlString += "<th>评论时间</th>";
            htmlString += "<th>回复</th>";
            htmlString += "</tr>";
            htmlString += "</thead>";
            htmlString += "<tbody>";
            foreach (Reply item in likes)
            {
                htmlString += "<tr>";
                htmlString += "<td><a><img src ='" + @item.Person.Avarda + "'style = 'width: 35px; height: 35px;'/> &nbsp;" + @item.Person.LastName + "</a></td>";
                htmlString += "<td>" + @item.Content + "</td>";
                htmlString += "<td><a href='#' class='reply' style='margin:0 20px'onclick=\"Like('ss');\"><i class='glyphicon glyphicon-thumbs-up' ></i>(" + item.Like + ")</a></td>";
                htmlString += "<td><a href='#' class='reply' style='margin:0 20px'><i class='glyphicon glyphicon-thumbs-down'></i>(" + item.Hate + ")</a></td>";
                htmlString += "<td>" + @item.CreateDateTime + "</td>";
                var sonCmt = _context.Replys.Where(x => x.ParentReply.ID == item.ID).ToList();
                htmlString += "<td><a href='#div-editor' class='reply' onclick=\"javascript:GetQuote('" + item.ID + "');\">回复</a>(<a href='#' class='reply'  onclick=\"javascript:ShowCmt('" + item.ID + "');\">" + sonCmt.Count + "</a>)条</td>";
                htmlString += "</tr>";
            }
            htmlString += "</tbody>";
            htmlString += "</table>";
            htmlString += "</div>";
            htmlString += "</div>";
            return Json(htmlString);



        }
    }
}