using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 登录的视图模型，用于用户输入的验证以及视图的呈现
    /// </summary>
    public class LoginViewModel
    {
        //此字段是必填
        [Required(ErrorMessage ="用户名不能为空")]
        //定义字段的呈现名称
        [Display(Name ="用户名")]
        public string UserName { get; set; }

        //前端按此数据类型显示
        [DataType(DataType.Password)]
        //此字段是必填
        [Required(ErrorMessage ="密码不能为空")]
        //定义字段的呈现名称
        [Display(Name ="密码")]
        public string PassWord { get; set; }
    }
}