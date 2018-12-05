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
                name: "Default",//默认路由表
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Helloworld", action = "Index", id = UrlParameter.Optional }
            );
            //添加
            routes.MapRoute(
              name: "Hello",//默认路由表
              url: "{controller}/{action}/{name}/{id}"
              );
        }
    }
}
