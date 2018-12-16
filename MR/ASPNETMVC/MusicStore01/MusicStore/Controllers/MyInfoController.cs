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
    public class MyInfoController : Controller
    {
        // GET: MyInfo
        public ActionResult Index(MyInfoViewModel myinfo)
        {

            //判断用户是否登录
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("index", "MyInfo") });
            //查询出当前用户
            var persons = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var context = new EntityDbContext();
            var person = context.Persons.Find(persons.ID);
            MyInfoViewModel retPerson = new MyInfoViewModel();
            if (ModelState.IsValid)
            {
                person.Address = myinfo.Address;
                person.Birthday = Convert.ToDateTime(myinfo.Birthay);
                person.Email = myinfo.Email;
                person.Name = myinfo.Name;
                person.Sex = myinfo.sex;
                person.TelephoneNumber = myinfo.TelePhoneNumber;
                
                context.SaveChanges();
            }
            else
            {
                retPerson.Address = person.Address;
                retPerson.Birthay = person.Birthday.ToString("yyyy-MM-dd");
                retPerson.Email = person.Email;
                retPerson.Name = person.Name;
                retPerson.sex = person.Sex;
                retPerson.TelePhoneNumber = person.TelephoneNumber;
            }
            //var p = new MyInfoViewModel(person);
            return View(retPerson);

        }
    }
}