using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class MyViewModel
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }

        [Display(Name = "地址")]
        [Required(ErrorMessage = "地址不能为空")]
        public string Address { get; set; }

        [Display(Name = "电话")]
        [Required(ErrorMessage = "电话不能为空")]
        public string TelePhoneNumber { get; set; }

        [Display(Name = "头像")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }
    }
}