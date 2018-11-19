using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo1.Controllers
{
    public class HelloWordController : Controller
    {
        // GET: HelloWord
        public string Index()
        {
            return "这是我的<b>默认的</b>控制器方法(action)";
        }

        public string Welcome(string name, int id = 1)
        {
            return "您好" + name + "欢迎次数" + id;

        }
    }
}