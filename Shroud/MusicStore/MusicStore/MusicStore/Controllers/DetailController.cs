using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class DetailController : Controller
    {
        static readonly MusicContext context=new MusicContext ();
        // GET: Detail
        public ActionResult Index(Guid id)
        {
            
            var album = context.Albums.Find(id);
            return View(album);
        }
    }
}