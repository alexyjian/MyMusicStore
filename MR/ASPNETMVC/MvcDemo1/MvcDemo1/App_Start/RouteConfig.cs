using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //添加一个新的路由
            routes.MapRoute(
               name: "Hello",
               url: "{controller}/{action}/{name}/{id}"
               //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
