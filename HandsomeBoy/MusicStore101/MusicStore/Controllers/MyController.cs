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
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        /// <summary>
        /// 个人信息显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Home") });
            var person = _context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
               var myVM = new MyViewModel()
                {
                    Name = person.Name,
                    Sex = person.Sex,
                    TelephoneNumber = person.TelephoneNumber,
                    MobileNumber = person.MobileNumber,
                    Email = person.Email,
                    Birthday = person.Birthday.ToString("yyyy-MM-dd"),
                    CredentialsCode = person.CredentialsCode
                };
                ViewBag.AvardaUrl = person.Avarda;
           
            return View(myVM);
        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MyViewModel model)
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Home") });
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
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), person.ID + ".jpg");//将网站的虚拟路径转化为真实 的物理路径
                    model.Avarda.SaveAs(imagePath);
                    oldAvarda = "/Upload/Avarda/" + person.ID + ".jpg";
                }

                person.Name = model.Name;
                person.Sex = model.Sex;
                person.TelephoneNumber = model.TelephoneNumber;
                person.MobileNumber = model.MobileNumber;
                person.Email = model.Email;
                person.Birthday =DateTime.Parse(model.Birthday);
                person.CredentialsCode = model.CredentialsCode;
                person.FirstName = person.Name.Substring(0, 1);
                person.Avarda = oldAvarda;
                person.LastName = person.Name.Substring(1, person.Name.Length - 1);
                _context.SaveChanges();


                return Content("<script>alert('修改个人信息成功!');location.href='" + Url.Action("index", "My") + "'</script>");
            }
           
            ViewBag.AvardaUrl = oldAvarda;
            return View();

        }
        // GET: My
        //显示和个人地址
        public ActionResult Address()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "Home") });
            var mya = new List<My>();
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            try
            {
                mya = _context.Mys.Where(x => x.Person.ID == person.ID).ToList();
                ViewBag.mya=mya;
            }
            catch { }
            return View();
        }
        //添加个人地址
        [HttpPost]
        public ActionResult Address(MusicStoreEntity.My model)
        {
           
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var my = new My()
            {
                AddressPerson = model.AddressPerson,
                Area = model.Area,
                MobiNumber = model.MobiNumber,
                Email = model.Email,
               Person = _context.Persons.Find(person.ID)
            };
            //Session["MyAdd"] = my;
            _context.Mys.Add(my);
            _context.SaveChanges();
            return Content("<script>alert('添加地址成功!');location.href='" + Url.Action("Address", "My") + "'</script>");
        }
        /// <summary>
        /// 删除Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddressRemove(Guid id)
        {
            var htmlString = "";

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //var carts = _context.Carts.Where(x => x.Person.ID == person.ID).ToList();
            var may1 = _context.Mys.Find(id);
            var order = _context.Orders.Where(x => x.Mys.ID == id).ToList();

            if (order.Count > 0)
            {
                return Json("无法删除有冲突");

            }
            var mays = _context.Mys.Find(id);
                _context.Mys.Remove(mays);
                _context.SaveChanges();
          
            //刷新局部视图  生成html元素注入到<tbody>中
            var may = _context.Mys.Where(x => x.Person.ID == person.ID).ToList();

            foreach (var item in may)
            {

                htmlString += "<tr>";

                htmlString += "<td> 收货人：" + item.AddressPerson + " </td>";

                htmlString += "<td> 所在地区：" + item.Area + "</td>";

                htmlString += "<td> 邮编：" + item.Email + " </td>";

                htmlString += "<td> 手机：" + item.MobiNumber + " </td>";

                htmlString += "  <td><span><a href = '../my/AddressUpdate/" + item.ID + "'> 修改 </a>";
                htmlString += " |<a href = 'javascript:;' class=\"delete\"onclick=\"Remove('" + item.ID + "')\">删除</a></span></td>";

                htmlString += " </tr>";

              
            }
            htmlString += " <tr><td></td ><td></td ><td></td><td></td><td></td></tr> ";

            return Json(htmlString);
        }
        /// <summary>
        /// 修改Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddressUpdate(Guid id)
        {
            var mays = _context.Mys.Find(id);
            My model = new My()
            {
                AddressPerson = mays.AddressPerson,
                Area = mays.Area,
                Email = mays.Email,
                MobiNumber = mays.MobiNumber,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddressUpdate(MusicStoreEntity.My model)
        {
            var mays = _context.Mys.Find(model.ID);

          
                mays.AddressPerson = model.AddressPerson;
            mays.Area = model.Area;
                mays.Email = model.Email;
            mays.MobiNumber = model.MobiNumber;

            _context.SaveChanges();
            return Content("<script>alert('地址修改成功!');location.href='" + Url.Action("Address", "My") + "'</script>");
        }
    }
}