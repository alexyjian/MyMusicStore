using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private static readonly EntityDbContext _dbContext = new EntityDbContext();
        // GET: Store
        public ActionResult Detail(Guid ID)
        {
            var detail = _dbContext.Albums.Find(ID);
            return View(detail);
        }
    }
}