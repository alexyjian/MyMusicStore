using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 用户信息视图模型
    /// </summary>
    public class MyViewModel
    {
        [Display(Name ="收件人姓名")]
        public string Name { get; set; }

        [Display(Name = "收件人地址")]
        public string Address { get; set; }

        [Display(Name = "收件人手机")]
        public string MobilNumber { get; set; }

        [Display(Name = "头像")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }
    }
}