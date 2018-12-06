using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ChangePassWordViewModel
    {
        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "新密码不能为空")]
        [Display(Name = "新密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}长度不能大于{1}小于{2}位", MinimumLength = 6)]
        public string PassWord { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "密码两次输入要一致")]
        public string ConfirmPassWord { get; set; }
    }
}