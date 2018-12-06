using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")] 
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "姓名不能为空")] 
        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")] 
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]+$",ErrorMessage = "请输入正确的Email格式")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")] 
        [Display(Name = "密码")]
        [StringLength(20,ErrorMessage = "{0}长度不能小于{1}大于{2}位",MinimumLength =6)]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage = "密码不一致")] //比较特性
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }
    }
}