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
    public class MyController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();

        // GET: My
        public ActionResult Index()
        {
            //1.判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            //2.读出当前用户person
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var myVM = new MyViewModel()
            {
                Name = person.Name,
                Address = person.Address,
                TelePhoneNumber = person.TelephoneNumber

            };
            ViewBag.AvardaUrl = person.Avarda;

            return View(myVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewModel model)
        {
            //1.判断用户登录凭据是否过期，如果过期跳转回登录页，登录成功后返回确认购买页
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            //2.读出当前用户person
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            //用户原来的头像
            var oldAvarda = person.Avarda;

            if(ModelState.IsValid)
            {
                //保存头像
                if(model.Avarda!=null)
                {
                    var uploadDir = "~/Upload/Avarda/";
                    var fileLaseName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".")+1,
                        (model.Avarda.FileName.Length-model.Avarda.FileName.LastIndexOf(".")-1));
                    //网站虚拟路径转化为真实的物理路径
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID + "." + fileLaseName);
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda= "/Upload/Avarda/" + person.ID + "."+fileLaseName;
                }
                //保存个人信息
                person.TelephoneNumber = model.TelePhoneNumber;
                person.Address = model.Address;
                person.Name = model.Name;
                person.FirstName = person.Name.Substring(0, 1);
                person.LastName = person.Name.Substring(1, person.Name.Length - 1);
                person.Avarda = oldAvarda;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.AvardeUrl = oldAvarda;
            return View();
        }
    }
}