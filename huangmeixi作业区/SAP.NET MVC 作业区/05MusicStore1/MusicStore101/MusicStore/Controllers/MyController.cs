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
        private static readonly EntityDbContext _context = new MusicStoreEntity. EntityDbContext();

        // 修改个人信息
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            var person =_context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);

            var myVM = new MyViewModel()
            {
                Name = person.Name,//姓名
                Sex = person.Sex,//性别
                Birthday = person.Birthday.ToString("yyyy-MM-dd"),//生日
                Address = person.Address,//收货地址
                MobilNumber = person.MobileNumber,//手机号码
     
            };

            ViewBag.AvardaUrl = person.Avarda;

            return View(myVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "My") });

            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            //用户原来的头像
            var oldAvarda = person.Avarda;
            if (ModelState.IsValid)
            {
                //保存头像
                if (model.Avarda != null)
                {
                    var uploadDir = "~/Upload/Avarda/";
                    //取后缀名
                    var fileLastName = model.Avarda.FileName.Substring(model.Avarda.FileName.LastIndexOf(".") + 1,
                        (model.Avarda.FileName.Length - model.Avarda.FileName.LastIndexOf(".") - 1));
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID + "." + fileLastName);  //将网站虚拟路径转化为真实的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda = "/Upload/Avarda/" + person.ID + "." + fileLastName;
                }

                //保存个人信息
                person.MobileNumber = model.MobilNumber;
                person.Sex = model.Sex;
                person.Birthday = DateTime.Parse(model.Birthday);
                person.Address = model.Address;
                person.Name = model.Name;
                person.FirstName = person.Name.Substring(0, 1);
                person.LastName = person.Name.Substring(1, person.Name.Length - 1);
                person.Avarda = oldAvarda;
                _context.SaveChanges();

                return Content("<script> alert('您已修改个人信息成功：');location.href='" + Url.Action("index", "My") + "'</script>");
                    
                return RedirectToAction("Index");
            }

            ViewBag.AvardaUrl = oldAvarda;
            return View();
        }
    }
}

