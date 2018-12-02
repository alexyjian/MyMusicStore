using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicStore101.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="用户不能为空")]//此字段是必填
        [Display(Name ="用户名")]//定义字段的呈现名称
        public string UserName { get; set; }

        [DataType(DataType.Password)]//前端按此数据类型显示
        [Required(ErrorMessage ="密码不能为空")]//此字段是必填
        [Display(Name ="密码")]//定义字段的呈现名称
        public string PassWord { get; set; }
    }
}