using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{/// <summary>
/// 用户信息视图模型
/// </summary>
    public class UpdatePersonalViewModel
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        [Display(Name = "收货地址")]
        [Required(ErrorMessage = "收货地址不能为空")]
        public string Address { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Display(Name = "电话号码")]
        public string MobileNumber { get; set; }

        [Display(Name = "头像")]
        [Required(ErrorMessage = "头像不能为空")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }

        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }
    }
}