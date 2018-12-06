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
    }
}