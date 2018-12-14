using Music.ViewModels;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
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
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }
            //2.查询出当前用户Person 查询该用户的购物项
            var persons = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
           
            var person = _context.Persons.SingleOrDefault(x=>x.ID==persons.ID);
            if (personAddress.AddresPerson != null)
            {
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
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

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
                htmlString += "<td style=\"width:250px\">"+item.AddresPerson+"</td>";
                htmlString += "<td style=\"width:400px\">"+item.Address+"</td>";
                htmlString += "<td style=\"width:100px\">"+item.MobileNumber+"</td>";
                htmlString += "<td style=\"width:100px\"><button onclick=\"removeAddres('"+item.ID+"')\" class=\"btn btn-success\"><i class=\"glyphicon glyphicon-shopping - cart\"></i>删除</button></td>";
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
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Buy", "Order") });

            }
            var persons = (Session["loginUserSessionModel"] as LoginUserSessionModel).Person;
            var address = _context.Persons.Find(persons.ID).PersonAddresss.ToList();
            return View(address);
        }
    }
}