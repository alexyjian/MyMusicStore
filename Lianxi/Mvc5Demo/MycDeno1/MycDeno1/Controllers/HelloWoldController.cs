﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MycDeno1.Controllers
{
    public class HelloWoldController : Controller
    {
        // GET: HelloWold
        public string Index()
        {
            return "这是我的<b>默认</b>控制器方法(action)";
        }
        public string Welcome( string name,int id)
        {
            return "您好"+name+"欢迎次数:"+id;
        }
    }
}