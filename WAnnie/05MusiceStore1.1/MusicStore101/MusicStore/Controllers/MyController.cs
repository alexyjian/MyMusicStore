using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        public static readonly MusicContext _Context = new MusicContext();
        // GET: My
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            //查询用户本人
            var person =_Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID) ;

            var name = new MyViewsModel()
            {
                Name = person.Name,
                Address = person.Address,
                MobilNumber = person.MobileNumber,
                Email = person.Email,
                Sex = person.Sex,
                Birthday = person.Birthday.ToString("yyyy-MM-dd")
            };

            ViewBag.AvardaUrL = person.Avarda;

            return View(name);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewsModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var person_update = _Context.Persons.Find(person.ID);
            //用户原来的头像
            var oldAvarda = person.Avarda;

            if (ModelState.IsValid)
            {
                //保存头像
                if (model.Avarda != null)
                {
                    var upload = "~/Upload/Avarda/";
                    //取后缀名
                    var fileLastName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".") + 1,
                        (model.Avarda.FileName.Length - model.Avarda.FileName.LastIndexOf(".") - 1));
                    //将网站虚拟路径转化为真实的物理路径
                    var imagesPath = Path.Combine(Server.MapPath(upload), person.ID + "." + fileLastName);

                    model.Avarda.SaveAs(imagesPath);
                    oldAvarda = "/Upload/Avarda/" + person.ID + "." + fileLastName;

                }

                //保存个人信息
                person_update.Name = model.Name;
                person_update.MobileNumber = model.MobilNumber;
                person_update.Address = model.Address;
                person_update.Email = model.Email;
                person_update.FirstName = person.Name.Substring(0, 1);
                person_update.LastName = person.Name.Substring(1, person.Name.Length - 1);
                person_update.Avarda = oldAvarda;
                person_update.Sex = model.Sex;
                person_update.Birthday=DateTime.Parse(model.Birthday);

                _Context.SaveChanges();

                return Content("<script>alert('修改个人信息成功!');location.href='" + Url.Action("index", "My") + "'</script>");
            }


            ViewBag.AvardaUrL = oldAvarda;
            return View();

        }
    }
}