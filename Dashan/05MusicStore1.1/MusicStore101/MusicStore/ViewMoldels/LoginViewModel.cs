using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewMoldels
{

    /// <summary>
    /// 登录的视图模型，用于用户输入的验证及视图的呈现
    /// </summary>
    public class LoginViewModel
    {
        //特性 Required  此字段必填
        [Required(ErrorMessage ="用户名不能为空")]
        [Display(Name ="用户名")]//定义字段呈现名称
        public string UserName { get; set; }

        [DataType(DataType.Password)]//前端按此数据类型显示
        [Required(ErrorMessage ="密码不能为空")]
        [Display(Name ="密码")]//定义字段呈现名称
        public string PassWord { get; set; }

    }
}