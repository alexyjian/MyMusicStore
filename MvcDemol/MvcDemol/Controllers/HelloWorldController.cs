using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemol.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "这是我的<b>默认</b>控制器方法（action）";
        }
        public string Welcome()
        {
            return "这是我的<b>默认</b>控制器方法（action）";
        }
    }
}