using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ChangePassWordViewModel
    {
        [Required(ErrorMessage = "密码不能为空")]//此字段生必填
        [Display(Name = "密码")]//定义字段的呈现名称
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "新密码不能为空")]//此字段生必填
        [Display(Name = "新密码")]//定义字段的呈现名称
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}长度不能小于{1}大于{2}位", MinimumLength = 6)]
        public string NewPassword { get; set; }


        [Display(Name = "确认信密码")]//定义字段的呈现名称
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "密码输入两次要一致")]
        public string ConfirNewPassword { get; set; }
    }
}
