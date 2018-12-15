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
                return Content("<script>alert('恭喜添加收货人成功!');location.href='" + Url.Action("index", "AddressPerson") + "'</script>");
            }
            else
            {
                return View();
            }
        
        }
        /// <summary>
        /// 修改收货人
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EidtAddressPerson(PerAddress PerAdd)
        {
            //判断用户是否登录如果没有跳转登录，登录成功后跳转回来
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("EidtAddressPerson", "AddressPerson") });

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            //修改
            if (PerAdd.Address != null)
            {
                var personadd = _context.PerAddress.SingleOrDefault(x => x.ID == PerAdd.ID);
                personadd.AddressPerson = PerAdd.AddressPerson;
                personadd.Address = PerAdd.Address;
                personadd.MobiNumber = PerAdd.MobiNumber;
                //_context.Order.Add(orders);
                _context.SaveChanges();
                return Content("<script>alert('恭喜修改收货人成功!');location.href='" + Url.Action("index", "AddressPerson") + "'</script>");
            }
            else
            {
                return View();
            }

        }
   
        public ActionResult EidtAddressPerson(Guid id)
        {
            //判断用户是否登录如果没有跳转登录，登录成功后跳转回来
            if (Session["LoginUserSessionModel"] == null)
                return RedirectToAction("login", "Account", new { returnUrl = Url.Action("EidtAddressPerson", "AddressPerson") });

            var personadd = _context.PerAddress.SingleOrDefault(x => x.ID == id);
            //将选中的收货人信息传给 EidtAddressPerson
            return View(personadd);
        }
        /// <summary>
        /// 删除收货人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveAddperson(Guid id)
        {
 
            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

            _context.PerAddress.Remove(_context.PerAddress.SingleOrDefault(x => x.ID == id));

            _context.SaveChanges();


            //重新生成Html脚本，返回json数据，局部刷新视图
            var htmlString = "";

            foreach (var item in person.PerAddress)
            {
                htmlString += "<tr>";
                htmlString += "<td style=\"line-height:40px;\"> "+ item.AddressPerson + "</td>";
                htmlString += "<td style=\"line-height:40px;\"> " + item.Address + "</td>";
                htmlString += "<td style=\"line-height:40px;\"> " + item.MobiNumber + "</td>";
              
                htmlString += "<td style=\"line-height:40px;\"> <a href='../EidtAddressPerson/AddressPerson/" + item.ID + "'> 修改</a> &nbsp; <a href=\"#\" onclick=\"RemoveDetail('" + item.ID + "');\"> </a> </td>";         
            }
            return Json(htmlString);
       
        }
    }
}