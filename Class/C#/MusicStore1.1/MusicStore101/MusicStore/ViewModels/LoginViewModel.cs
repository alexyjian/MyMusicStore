using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 登录的视图模型，用于用户验证输入以及视图的呈现
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")] //必填字段
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")] //必填字段
        [Display(Name = "密码")]
        public string PassWord { get; set; }
    }
}