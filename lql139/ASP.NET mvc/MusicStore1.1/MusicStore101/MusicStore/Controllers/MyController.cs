using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class MyController : Controller
    {
        private readonly EntityDbContext _context = new EntityDbContext();
        // GET: My
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { retunUrl = Url.Action("index", "ShoppingCart") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            // var carts = _context.Orders.Where(x => x.Person.ID == person.ID).ToList();

            return View(person);
        }
        [HttpPost]
        public ActionResult CompilePersonal(Guid id)
        {
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var htmlString = "";

            htmlString += "<div class=\"panel-heading\"><h3 class=\"panel-title\">个人信息</h3></div>";
            htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">名称:</span><input type = \"text\" class=\"form-control\" placeholder=\"name\" value=" + person.Name + "></div></div>";
            htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">电话:</span><input type = \"text\" class=\"form-control\" placeholder=\"phone\" value=" + person.MobileNumber + "></div></div>";
            htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">邮箱:</span><input type = \"text\" class=\"form-control\" placeholder=\"Email\" value=" + person.Email + "></div></div>";
            htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">地址:</span><input type = \"text\" class=\"form-control\" placeholder=\"Email\" value=" + person.Address + "></div></div>";
            htmlString += "<button onclick=\"UpdatePersonal('" + person.ID + "')\" type=\"submit\" class=\"btn btn-default\" style=\"float:right; margin-right:10px; margin-top:50px;\">保存</button>";
            return Json(htmlString);
        }
        public ActionResult UpdatePersonal(UpdatePersonalViewModel model)
        {
            var userManage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDbContext()));
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            if (ModelState.IsValid)
            {
                var htmlString = "";

                htmlString += "<div class=\"panel-heading\"><h3 class=\"panel-title\">个人信息</h3></div>";
                htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">名称:</span><input type = \"text\" class=\"form-control\" placeholder=\"name\" value=" + person.Name + "></div></div>";
                htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">电话:</span><input type = \"text\" class=\"form-control\" placeholder=\"phone\" value=" + person.MobileNumber + "></div></div>";
                htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">邮箱:</span><input type = \"text\" class=\"form-control\" placeholder=\"Email\" value=" + person.Email + "></div></div>";
                htmlString += "<div class=\"panel-body\"><div class=\"input-group CompilePersonal-text\"><span class=\"input-group-addon\">地址:</span><input type = \"text\" class=\"form-control\" placeholder=\"Email\" value=" + person.Address + "></div></div>";
                htmlString += "<button onclick=\"UpdatePersonal('" + person.ID + "')\" type=\"submit\" class=\"btn btn-default\" style=\"float:right; margin-right:10px;\">编辑</button>";
                return Json(htmlString);
            }
            return View(model);
        }
    }
}