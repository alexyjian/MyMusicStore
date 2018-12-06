using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class PwdViewModel
    {
        [Required(ErrorMessage = "旧密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        public string oldPassword { get; set; }

        [Required(ErrorMessage = "新密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        [StringLength(20, ErrorMessage = "{0}长度不能小于{1}大于{2}位", MinimumLength = 6)]
        public string newPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("newPassword",ErrorMessage = "密码不一致")]
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }
    }
}