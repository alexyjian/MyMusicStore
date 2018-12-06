using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewMoldels
{
    /// <summary>
    /// 注册的视图模型
    /// </summary>
    public class RegisterViewModel
    {

        //必填项
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        //必填项
        [Required(ErrorMessage = "性名不能为空")]
        [Display(Name = "性名")]
        public string FullName { get; set; }

        //必填项
        [Required(ErrorMessage = "邮箱不能为空")]
        [Display(Name = "邮箱")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "请输入正确的电子邮箱地址！")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password )]
        [StringLength (20,ErrorMessage = "{0}长度不能小于{1}大于{2}位", MinimumLength = 6)]
        public  string PassWord { get; set; }


        [Required(ErrorMessage = "确认密码")]
        [Display(Name = "新密码")]
        [DataType(DataType.Password)]
       [Compare("PassWord",ErrorMessage ="密码两次输入要一致")]
        public string ConfirmPassWord { get; set; }

    }
}