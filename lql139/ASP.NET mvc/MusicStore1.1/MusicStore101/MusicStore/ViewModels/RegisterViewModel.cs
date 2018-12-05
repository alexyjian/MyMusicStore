using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="用户名不能为空")]
        [Display(Name ="登录名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "姓名名不能为空")]
        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "邮箱名不能为空")]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]+$",ErrorMessage ="邮箱格式不正确") ]
        public string Email { get; set; }

        [Required(ErrorMessage = "密码名不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(20,ErrorMessage ="{0}长度不能小于{2}位",MinimumLength =6)]
        public string PassWord { get; set; }

        [Display(Name = "确认")]
        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage ="两次密码必须一致")]
        public string ConfirmPassWord { get; set; }

    }
}