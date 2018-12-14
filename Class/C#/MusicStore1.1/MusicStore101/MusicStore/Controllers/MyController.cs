using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
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
        private static readonly MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        /// <summary>
        /// 修改密码视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 修改密码业务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PwdViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.EntityDbContext()));
                    var user = usermanager.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).User.UserName, model.oldPassword);
                    if (user != null)
                    {
                        bool b = usermanager.ChangePassword(user.Id, model.oldPassword, model.newPassword).Succeeded;
                        if (b)
                            return Content("<script>alert('修改密码成功！');location.href = '" + Url.Action("Index", "Home") + "'</script>");
                        else
                            return Content("<script>alert('修改失败，请重试！');location.href = '" + Url.Action("Index", "My") + "'</script>");
                    }
                }
                catch
                {
                    return View();
                }
            }
            return View(model);
        }

        /// <summary>
        /// 我的信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Info(InfoViewModel model)
        {
            return View();
        }

        /// <summary>
        /// 收件地址信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddressInfo()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AddressInfo", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var ars = _context.PeopleAddress.Where(x => x.Person.ID == person.ID).ToList();

            return View(ars);
        }

        [HttpPost]
        public ActionResult AddressInfo()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AddressInfo", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var ars = _context.PeopleAddress.Where(x => x.Person.ID == person.ID).ToList();

            return View(ars);
        }

        public ActionResult Addaddress()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Addaddress", "My") });
            
            return View();
        }
    }
}