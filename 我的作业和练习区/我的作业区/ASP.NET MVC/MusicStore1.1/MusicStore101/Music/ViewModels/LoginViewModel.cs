using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.ViewModels
{
    /// <summary>
    /// 登陆的视图模型，用于用户输入的验证以及视图的呈现
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]//此字段是必填的
        [Display(Name = "用户名")]//定义字段的呈现名称
        public string Username { get; set; }
        [DataType(DataType.Password)]//前段按此数据类型显示
        [Required(ErrorMessage = "用户名不能为空")]//此字段是必填的
        [Display(Name = "密码")]//定义字段的呈现名称
        public string PassWord { get; set; }
    }
}