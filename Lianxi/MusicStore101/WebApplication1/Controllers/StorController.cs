using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StorController : Controller
    {/// <summary>
    /// 显示专辑明细
    /// </summary>
    /// <returns></returns>
        // GET: Stor
        public ActionResult Index()
        {
            return View();
        }
    }
}