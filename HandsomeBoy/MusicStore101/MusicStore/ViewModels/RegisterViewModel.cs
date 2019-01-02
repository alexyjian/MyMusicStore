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
        [Display(Name = "登录名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [Display(Name = "姓名")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]//必填
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)] //验证邮箱格式
        [RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$", ErrorMessage = "请输入正确的Email格式！")]
        public string Email{ get; set; }

        [Required(ErrorMessage =" 密码不能为空")]//必填
        [Display(Name = "密码")]//显示的中文名
        [DataType(DataType.Password)] //验证密码格式
        [StringLength(20,ErrorMessage ="{0},密码长度不能大于{1}小于{2}位",MinimumLength=6)]
        public string PassWord { get; set; }

        [Display(Name = "确认密码")]//显示的中文名
        [DataType(DataType.Password)] //验证密码格式
        [Compare("PassWord",ErrorMessage ="两次密码输入要一致")]
        public string ConfirmPassWord { get; set; }
    }
}