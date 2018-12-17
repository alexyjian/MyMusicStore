using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStore.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Info()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Info", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var yearList = new List<SelectListItem>();
            var monthList = new List<SelectListItem>();
            var dayList = new List<SelectListItem>();
            //year
            for (int i = 1900; i <= DateTime.Now.Year; i++)
                yearList.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });

            //month
            for (int i = 1; i <= 12; i++)
                monthList.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            
            //day
            for (int i = 1; i <= 31; i++)
                dayList.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });

            ViewBag.years = yearList;
            ViewBag.months = monthList;
            ViewBag.days = dayList;

            var InfoModel = new InfoViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                BrithDay = person.Birthday,
                MobileNumber = person.MobileNumber,
                Sex = person.Sex
            };
            ViewBag.AvardaUrl = person.Avarda;
            return View(InfoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Info(InfoViewModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Info", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var oldAvarda = person.Avarda;

            if (ModelState.IsValid)
            {
                if (model.Avarda != null)
                {
                    var uploadDir = "~/Upload/Avarda";
                    var fileLastName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".") + 1,
                        (model.Avarda.FileName.Length - model.Avarda.FileName.LastIndexOf(".") - 1));
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID + "." + fileLastName);  //将网站虚拟路径转化为真实的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda = "/Upload/Avarda/" + person.ID + "." + fileLastName;
                }

                person.MobileNumber = model.MobileNumber;
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Name = model.FirstName + model.LastName;
                person.Avarda = oldAvarda;
                var date = model.BrithDay.Year;
                person.Sex = model.Sex;

                _context.SaveChanges();
                return RedirectToAction("Index", "My");
            }
            ViewBag.AvardaUrl = oldAvarda;
            return RedirectToAction("Info", "My");
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
                htmlString += "<td class='mobilenumber'><a href = '#' onclick=" + '"' + "remove('" + item.ID + "')" + '"' + "> 删除 </ a ></ td > ";
                htmlString += "</tr>";
            }
            return Json(htmlString);
        }
    }
}