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
                    Content=model.Content,
                    Person=model.Person,
                    Album=model.Album,
                    CreateDateTime= DateTime.Now,
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

        [HttpPost]

        public ActionResult RemoveDetail(Guid id,string content)
        {
            //判断用户是否登陆
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
            }
            //查询出当前登陆用户
            var person = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;

            var replys = new Reply()
            {
               
                Content = content,
                Person = _context.Persons.Find(person.ID),
                Album = _context.Albums.Find(id)
            };
            
            _context.Replys.Add(replys);
            _context.SaveChanges();
            var reps = _context.Replys.Where(x => x.Album.ID == id).OrderByDescending(x => x.CreateDateTime);
            var htmlString = "";
            foreach (var item in reps)
            {
                htmlString += "<div id='demo' class='table - responsive collapse'>";
                htmlString += "<table class='table table-hover '>";
                htmlString += "<tbody>";
                htmlString += "<tr>";

                htmlString += "<td>" + "<img src = " + @item.Person.Avarda + "/>" + @item.Person.LastName + "</td>";
                htmlString += "<td>" + @item.Content + "</td>";
                htmlString += "<td>" + @item.CreateDateTime + "</td>";
                htmlString += "<a href=\"javascript:; \" >回复</a>";
                htmlString += "</tr>";
                htmlString += "</tbody>";
                htmlString += "</table>";
                htmlString += "</div>";
            }

            return Json(htmlString);


        }

        [HttpPost]
        [ValidateInput(false)]//关闭验证
        public ActionResult AddCmt(string id, string cmt, string reply)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");
            var person=_context.Persons.Find((Session["LoginUserSessionModel"]as LoginUserSessionModel).Person.ID);
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
                //顶级回复
                r.ParentReply = null;
            }
            else
            {
                r.ParentReply = _context.Replys.Find(Guid.Parse(reply));
            }
            _context.Replys.Add(r);
            _context.SaveChanges();

                return Json("OK");
        }
       
        }
}