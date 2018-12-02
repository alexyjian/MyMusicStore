using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="用户名不能为空")]//此字段必填
        [Display(Name ="用户名")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="密码不能为空")]
        [Display(Name ="密码")]
        public string PassWord { get; set; }
    }
}