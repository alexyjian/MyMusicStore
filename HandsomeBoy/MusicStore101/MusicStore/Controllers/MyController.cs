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
        public ActionResult Index()
        {
            var list = _context.Mys.OrderBy(x => x.AddressPerson).ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult add(MusicStoreEntity.My model)
        {
            var my = new My()
            {
                AddressPerson = model.AddressPerson,
                Address =model.Address,
                Area = model.Area,
                MobiNumber = model.MobiNumber,
                Email = model.Email
            };
            _context.Mys.Add(my);
            _context.SaveChanges();
             return Json("<script> alert(添加成功)</script>");
        }
    }
}