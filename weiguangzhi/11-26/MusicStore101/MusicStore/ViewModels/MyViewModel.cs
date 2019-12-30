using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class MyViewModel
    {
        [Display(Name="收件人姓名")]
        [Required(ErrorMessage ="收件人姓名不能为空")]
        public string Name { get; set; }

        [Display(Name = "收件人地址")]
        [Required(ErrorMessage = "收件人地址不能为空")]
        public string Address { get; set; }

        [Display(Name = "收件人号码")]
        [Required(ErrorMessage = "收件人号码不能为空")]
        public string MobilNumber { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "性别不能为空")]
        public bool Sex { get; set; }

        [Display(Name = "出生日期")]
        [Required(ErrorMessage = "性别不能为空")]
        public DateTime Birthday { get; set; } // 出生日期

        [Display(Name = "头像")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }

        
    }
}