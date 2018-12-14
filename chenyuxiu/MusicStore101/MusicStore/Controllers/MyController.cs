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
        private static readonly EntityDbContext _context = new EntityDbContext();
        // GET: My
        public ActionResult Index()
        {

            EntityDbContext _context = new EntityDbContext();

            var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;
            var orders = Session["Order"] as Order;
            //创建新的Order对象、
            var order = new Order()
            {
                AddressPerson = person.Name,
                MobilNumber = person.MobileNumber,
                Person = _context.Persons.Find(person.ID),

            };
            return View();
        }
    }
}