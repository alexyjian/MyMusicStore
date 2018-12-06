using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "老密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码名不能为空")]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "密码名不能为空")]
        [Display(Name = "新的密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}长度不能小于{2}位", MinimumLength = 6)]
        public string PassWord { get; set; }

       
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "两次密码必须一致")]
        public string NewPassWord { get; set; }

      
    }
}