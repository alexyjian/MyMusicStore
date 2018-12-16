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
        public string Name { get; set; }

        //性别验证
        [Display(Name = "性别")]
        public bool sex { get; set; }

        //电话号码验证
        [Display(Name = "手机号")]
        public string TelePhoneNumber { get; set; }

        //邮箱验证
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        //收货地址验证
        [Display(Name = "收货地址")]
        public string Address { get; set; }

        //生日     
        [Display(Name = "生日")]
        public DateTime Birthay { get; set; }

        [Display(Name="头像")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }
    }
}