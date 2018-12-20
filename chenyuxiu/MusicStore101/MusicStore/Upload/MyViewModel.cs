using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    /// <summary>
    /// 用户信息视图模型
    /// </summary>
    public class MyViewModel
    {
        [Display(Name = "收件人姓名")]
        [Required(ErrorMessage = "收件人姓名不能为空")]
        public string Name { get; set; }


        [Required(ErrorMessage="用户名不能为空")]
            [Display(Name="性别：")]//性别
            public bool Sex { get; set; } //性别


        [Display(Name = "收货地址")]
        [Required(ErrorMessage = "收货地址不能为空")]
        public string Address { get; set; }

        [Display(Name="收件人手机")]
        [Required(ErrorMessage = "收件人手机不能为空")]
        public string MobilNumber { get; set; }


        [Required(ErrorMessage = "出生年月日")]
        [Display(Name = "出生日期：")]//出生日期
        public string Birthday { get; set; } //出生日期

        [Display(Name = "头像")]
        [DataType (DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }

    }
}