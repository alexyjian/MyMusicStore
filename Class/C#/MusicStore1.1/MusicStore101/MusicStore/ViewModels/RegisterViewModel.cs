using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")] //必填字段
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")] //必填字段
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")] //必填字段
        [Display(Name = "密码")]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "确认密码不能为空")] //必填字段
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }
    }
}