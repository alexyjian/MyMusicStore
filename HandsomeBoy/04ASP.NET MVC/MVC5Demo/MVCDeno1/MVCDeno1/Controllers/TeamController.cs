using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDeno1.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Member()
        {
            return View();
        }
        public ActionResult Item()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}