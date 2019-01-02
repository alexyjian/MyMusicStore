using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ChangePassWordViewModel
    {
        [Required(ErrorMessage = " 密码不能为空")]//必填
        [Display(Name = "密码")]//显示的中文名
        [DataType(DataType.Password)] //验证密码格式
        [StringLength(20, ErrorMessage = "{0},密码长度不能大于{1}小于{2}位", MinimumLength = 6)]
        public string NewPassWord { get; set; }

        [Display(Name = "确认密码")]//显示的中文名
        [DataType(DataType.Password)] //验证密码格式
        [Compare("NewPassWord", ErrorMessage = "两次密码输入要一致")]
        public string ConfirmPassWord { get; set; }


    }
}