using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewsModel
{
    public class MyViewsModel
    {
        //收件人
        [Display(Name = "收件人姓名")]
        [Required(ErrorMessage = "收件人姓名不能为空")]
        public string Name { get; set; }

        //地址
        [Display(Name = "收货地址")]
        [Required(ErrorMessage = "地址不能为空")]
        public string Address { get; set; }

        //性别
        [Display(Name = "性别")]
        [Required(ErrorMessage = "性别不能为空")]
        public bool Sex { get; set; }

        //生日
        [Display(Name = "生日")]
        [Required(ErrorMessage = "生日不能为空")]
        public string Birthday { get; set; }

        //手机号码
        [Display(Name = "手机号")]
        [Required(ErrorMessage = "手机号不能为空")]
        public string MobilNumber { get; set; }

        //邮政编码
        [Display(Name = "邮政编码")]
        [Required(ErrorMessage = "邮政编码不能为空")]
        public string Email { get; set; }


        [Display(Name = "头像")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }
    }
}