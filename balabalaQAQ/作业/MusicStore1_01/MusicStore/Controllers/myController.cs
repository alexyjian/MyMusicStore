using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class myController : Controller
    {
            
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: my
        public ActionResult Index()
        {
            //1.确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "my") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var my = new MYviewModel()
            {
                MobileNumber = person.MobileNumber,
                Name=person.Name,
                
            };
            ViewBag.AvardaUrl = person.Avarda;
            return View(my);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MYviewModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "my") });
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            //用户原来的头像
            var oldAvarad = person.Avarda;

            if (ModelState.IsValid)
            {
                //保存头像
                if (model.Avarda != null)
                {
                    var uploadDir = "~/Upload/Avarda/";
                    var fileLastName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".") + 1,
                        (model.Avarda.FileName.Length - model.Avarda.FileName.LastIndexOf(".") - 1));
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID + "." + fileLastName);//将图片虚拟路径转化为真实的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarad = "/Upload/Avarda/" + person.ID + ".jpg";
                }
                //保存个人信息
                person.Avarda = oldAvarad;
                person.Name = model.Name;
                _context.SaveChanges();
            }
            ViewBag.AvardaUrl = oldAvarad;
            return View();
        }
    }
}