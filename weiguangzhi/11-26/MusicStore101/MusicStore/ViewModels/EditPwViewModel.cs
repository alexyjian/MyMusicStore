using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class EditPwViewModel
    {

        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "{0}长度不能小于{2}位", MinimumLength = 6)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "新密码不能为空")]
        [Display(Name = "新密码密码")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "{0}长度不能小于{2}位", MinimumLength = 6)]
        public string NewPassWord { get; set; }

        [Display(Name = "确认新密码")]
        [DataType(DataType.Password)]
        [Compare("NewPassWord", ErrorMessage = "新密码不能为空")]
        public string NewConfirmPassWord { get; set; }
    }
}