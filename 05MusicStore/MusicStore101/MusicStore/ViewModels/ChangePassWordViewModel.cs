using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ChangePassWordViewModel
    {
        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}密码长度不能短于6位", MinimumLength = 6)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}密码长度不能短于6位", MinimumLength = 6)]
        public string NewPassWord { get; set; }

        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}密码长度不能短于6位", MinimumLength = 6)]
        [Compare("NewPassWord",ErrorMessage ="密码两次输入要一致")]
        public string ConfirmNewPassWord { get; set; }
    }
}