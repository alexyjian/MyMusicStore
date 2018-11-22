using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)//默认路由表
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HelloWorld", action = "Index", id = UrlParameter.Optional }//可手动更改控制
            );

            //添加一个新的路由
            routes.MapRoute(
                name: "Hello",
                url: "{controller}/{action}/{name}/{id}"
                );
        }

    }
}
