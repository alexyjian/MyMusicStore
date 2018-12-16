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

        /// <summary>
        /// 收件地址信息
        /// </summary>
        /// <param name="peopleaddress"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressInfo(PeopleAddress peopleaddress)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AddressInfo", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var info = new PeopleAddress()
            {
                Address = peopleaddress.Address,
                MobileNumber = peopleaddress.MobileNumber,
                Name = peopleaddress.Name
            };
            info.Person = _context.Persons.Find(person.ID);
            _context.PeopleAddress.Add(info);
            _context.SaveChanges();
            return RedirectToAction("AddressInfo", "My");
        }

        /// <summary>
        /// 添加收获地址页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Addaddress()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Addaddress", "My") });
            
            return View();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Remove(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AddressInfo", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var del = _context.PeopleAddress.Find(id);
            _context.PeopleAddress.Remove(del);
            _context.SaveChanges();
            var ads = _context.PeopleAddress.Where(x => x.Person.ID == person.ID).ToList();
            var htmlString = "";
            foreach (var item in ads)
            {
                htmlString += "<tr><td>" + item.Name + "&nbsp; &nbsp;<span class='mobilenumber'>" + item.MobileNumber + "</span><br /><span class='address'>" + item.Address + "</span></td>";
                htmlString += "<td class='mobilenumber'><a href='@Url.Action('EditAddress','My',new{id="+item.ID+"})'>编辑</a>&nbsp;&nbsp;<a href = '#' onclick=" + '"' + "remove('" + item.ID + "')" + '"' + "> 删除 </ a ></ td > ";
                htmlString += "</tr>";
            }
            return Json(htmlString);
        }

        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditAddress(Guid id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("AddressInfo", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var ad = _context.PeopleAddress.Find(id);
            return View(ad);
        }

        /// <summary>
        /// 修改地址信息
        /// </summary>
        /// <param name="peopleaddress"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(PeopleAddress peopleaddress)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("EditAddress", "My") }); 
            _context.SaveChanges();
            return RedirectToAction("AddressInfo", "My");
        }

        public void DateTimer()
        {
            var yearList = new List<SelectListItem>();
            var monthList = new List<SelectListItem>();
            var dayList = new List<SelectListItem>();
            for (int y = 1900; y <= DateTime.Now.Year; y++)
            {
                yearList.Add(new SelectListItem() { Text = y.ToString(), Value = y.ToString() });
            }

            for (int m = 1; m <= 12; m++)
            {
                if()
            }
        }
    }
}