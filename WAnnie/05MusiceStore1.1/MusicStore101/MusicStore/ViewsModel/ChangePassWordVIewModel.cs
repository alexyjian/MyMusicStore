using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewsModel
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class ChangePassWordVIewModel
    {
        
        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "新密码不能为空")]
        [Display(Name = "新密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}长度不能小于{1}大于{2}位", MinimumLength = 6)]
        public string NewPassWord { get; set; }



        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("NewPassWord", ErrorMessage = "密码两次输入要正确")]
        public string ConfirmNewPassword { get; set; }
    }
}