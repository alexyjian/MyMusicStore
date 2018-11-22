using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HelloWorldController : Controller //控制类
    {
        // GET: HelloWorld

        public ActionResult Index()
        {
            return View();
        }

        //public string Index()
        //{
        //    //return View();//默认返回View 前端
        //    return "这是我的 <b> 默认 </b>控制器(action)";
        //}
        ////public string Welcome()
        ////{
        ////    //强调所选字体成粗体 <b> 欢迎 </b> 
        ////    return "这是我的 <b> 欢迎 </b>控制器方法(action)";
        ////}




             //带参数
        public ActionResult Welcome(string  name,int id=1)
        {

            //return "您好,"+ name + "欢迎次数："+ id;

            ViewBag.ID = id;
            ViewBag.Name = name + ",您好！";
            Session["message"] = "你们很棒棒的！";
            return View();
        }
    }
}