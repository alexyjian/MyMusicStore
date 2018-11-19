using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo1.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "这是我的<b>默认</b>控制器(action)";
        }

        public string WelCome()
        {
            return "这是我的<b>欢迎</b>控制器(action)";
        }
    }
}