using MusicStore.ViewModels;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{

    public class AddressPersonController : Controller
    {
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: AddressPerson
        public ActionResult Index()
        {
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Order") });

            //2.查询出当前用户Person 查询该用户的购物项
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var Peradd = _context.Persons.Find(person.ID).PerAddress.ToList();

            return View(Peradd);
        }
        public ActionResult AddressPerson(PerAddress PerAdd)
        {
            //1.确认用户是否登录 是否登录过期
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("AddressPerson", "Order") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            if (PerAdd.Address != null)
            {
                var peradd = new PerAddress()
                {
                    Address = PerAdd.Address,
                    AddressPerson = PerAdd.AddressPerson,
                    MobiNumber = PerAdd.MobiNumber
                };
                var personadd = _context.Persons.SingleOrDefault(x => x.ID == person.ID);

                personadd.PerAddress.Add(peradd);
                //_context.Order.Add(orders);
                _context.SaveChanges();
            }
            else
            {
                return View();
            }

            return Content("<script>alert('恭喜添加收货人成功!');location.href='" + Url.Action("AddressPerson", "AddressPerson"));                           "'</script>");
        }
        /// <summary>
        /// 修改收货人
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EidtAddressPerson(Guid id)
        {
            //判断用户是否登录如果没有跳转登录，登录成功后跳转回来
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("EidtAddressPerson", "AddressPerson") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var personadd = _context.PerAddress.SingleOrDefault(x => x.ID == id);
            //修改
             _context.SaveChanges();

            return View();
        }
        [HttpPost]
        public ActionResult RemoveAddperson(Guid id)
        {
 
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            _context.PerAddress.Remove(_context.PerAddress.SingleOrDefault(x => x.ID == id));

            _context.SaveChanges();

            return View();
        }
    }
}