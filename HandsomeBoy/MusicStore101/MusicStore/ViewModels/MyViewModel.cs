using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class MyViewModel
    {
      
        public Guid ID { get; set; }
        [Display(Name = "姓名：")]//显示的中文名
        [Required(ErrorMessage = "用户名不能为空")]
        public string Name { get; set; } // 全名

        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "性别：")]//性别
        public bool Sex { get; set; } // 性别

        [Required(ErrorMessage = "电话号码")]
        [Display(Name = "电话号码：")]//电话号码
        public string TelephoneNumber { get; set; } // 电话号码

        [Required(ErrorMessage = "手机号码")]
        [Display(Name = "手机号码：")]//手机号码
        public string MobileNumber { get; set; } // 手机号码

        [Required(ErrorMessage = "电子邮箱")]
        [Display(Name = "电子邮箱：")]//电子邮箱
        public string Email { get; set; } // 电子邮箱

        [Required(ErrorMessage = "出生日期")]
        [Display(Name = "出生日期：")]//出生日期
        public string Birthday { get; set; } // 出生日期

        [Required(ErrorMessage = "身份证编号")]
        [Display(Name = "身份证编号：")]//身份证编号
        public string CredentialsCode { get; set; } // 身份证编号

        [Required(ErrorMessage = "头像")]
        [Display(Name = "头像：")]//头像
        public HttpPostedFileBase Avarda { get; set; } //头像

       
    }
}