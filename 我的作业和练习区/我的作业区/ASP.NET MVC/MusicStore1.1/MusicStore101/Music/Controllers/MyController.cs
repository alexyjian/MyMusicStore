using Music.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Controllers
{
    public class MyController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PersonAddress personAddress)
        {
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("Buy", "Order")});

            }

            //2.查询出当前用户Person 查询该用户的购物项
            var persons = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var person = _context.Persons.SingleOrDefault(x => x.ID == persons.ID);
            if (personAddress.AddresPerson != null)
            {
                personAddress.persons = person;
                person.PersonAddresss.Add(personAddress);
                _context.SaveChanges();
                return Content("<script>alert('添加成功!');location.href='" + Url.Action("index", "My") + "'</script>");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Remove(Guid id)
        {
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("Buy", "Order")});

            }

            var persons = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var addres = _context.PersonAddresss.Find(id);
            _context.PersonAddresss.Remove(addres);
            _context.SaveChanges();

            var address = _context.Persons.Find(persons.ID).PersonAddresss.ToList();
            var htmlString = "";
            foreach (var item in address)
            {
                htmlString += "<tr>";
                htmlString += "<td style=\"width:250px\">" + item.AddresPerson + "</td>";
                htmlString += "<td style=\"width:400px\">" + item.Address + "</td>";
                htmlString += "<td style=\"width:100px\">" + item.MobileNumber + "</td>";
                htmlString += "<td style=\"width:100px\"><button onclick=\"removeAddres('" + item.ID +
                              "')\" class=\"btn btn-success\"><i class=\"glyphicon glyphicon-shopping - cart\"></i>删除</button></td>";
                htmlString += "</tr>";
            }

            return Json(htmlString);
        }

        // GET: My
        public ActionResult Index()
        {
            //1.确认用户是否登陆 是否登陆过期
            if (Session["loginUserSessionModel"] == null)
            {
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("Buy", "Order")});

            }

            var persons = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var address = _context.Persons.Find(persons.ID).PersonAddresss.ToList();

            return View(address);
        }

        /// <summary>
        /// 查看个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult MyIndex()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("Index", "My")});

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            var myVM = new MyViewModel()
            {
                Name = person.Name,
                Address = person.Address,
                MobiNumber = person.MobileNumber,
                Sex = person.Sex,
                Birthday = person.Birthday
            };

            ViewBag.AvardaUrl = person.Avarda;

            return View(myVM);
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyIndex(MyViewModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new {returnUrl = Url.Action("Index", "My")});

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
                    var imagePath =
                        Path.Combine(Server.MapPath(uploadDir), person.ID + "." + fileLastName); //将网站虚拟路径转化为真实的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda = "/Upload/Avarda/" + person.ID + "." + fileLastName;
                }

                //保存个人信息
                person.MobileNumber = model.MobiNumber;
                person.Address = model.Address;
                person.Name = model.Name;
                person.FirstName = person.Name.Substring(0, 1);
                person.LastName = person.Name.Substring(1, person.Name.Length - 1);
                person.Avarda = oldAvarda;
                person.Sex = model.Sex;
                person.Birthday = model.Birthday;
                person.UpdateTime=DateTime.Now;

                _context.SaveChanges();

                return RedirectToAction("MyIndex");
            }

            ViewBag.AvardaUrl = oldAvarda;
            return View();
        }
    }

}