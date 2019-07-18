using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.ViewModels
{
    public class MyViewModel
    {
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "性别")]
        public bool Sex { get; set; }
        [Display(Name = "手机号")]
        public string MobiNumber { get; set; }
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }
        [Display(Name = "头像")]
        [DataType(DataType.Upload)]
        public  HttpPostedFileBase Avarda { get; set; }
    }
}