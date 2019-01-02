using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new EntityDbContext();
            //传入24条专辑到视图
            var list = context.Albuns.OrderByDescending(x => x.PublsherDate).Take(24).ToList();
           
            return View(list);
        }
        
      
    }
}