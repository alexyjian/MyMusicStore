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
            return "这是我的<b>默认</b>控制方法(action)";
        }

        public string Welcome(string name,int id=1)
        {
            return "您好，" + name + ",欢迎次数:"+id;
        }
    }
}