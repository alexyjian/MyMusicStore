using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MyController : Controller
    {
        private static MusicStoreEntity.EntityDbContext _context = new MusicStoreEntity.EntityDbContext();
        // GET: My
        //显示和添加个人地址
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "login", new { returnUrl = Url.Action("index", "ShoppingCart") });
            var mya = new List<My>();
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            mya = _context.Mys.Where(x => x.Person.ID == person.ID).ToList();
            Session["asdasd"] = mya;
            return View();
        }
        //添加个人地址
        [HttpPost]
        public ActionResult Add(MusicStoreEntity.My model)
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
            return Content("<script>alert('添加地址成功!');location.href='" + Url.Action("Index", "My") + "'</script>");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Remove(Guid id)
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

                htmlString += "  <td><span><a href = '../my/update/" + item.ID + "'> 修改 </a>";
                htmlString += " |<a href = 'javascript:;' class=\"delete\"onclick=\"Remove('" + item.ID + "')\">删除</a></span></td>";

                htmlString += " </tr>";

              
            }
            htmlString += " <tr>< td ></td ><td></td ><td></td> <td></td><td></td></tr> ";

            return Json(htmlString);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(Guid id)
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
        public ActionResult Update(MusicStoreEntity.My model)
        {
            My mays = new My()
            {
                AddressPerson = model.AddressPerson,
                Area = model.Area,
                Email = model.Email,
                MobiNumber = model.MobiNumber,
            };
            _context.SaveChanges();
            return Content("<script>alert('地址修改成功!');location.href='" + Url.Action("Index", "My") + "'</script>");
        }
    }
}