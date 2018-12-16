using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewMoldels
{

    /// <summary>
    /// 我的收货信息 视图模型
    /// </summary>
    public class MyViewModel
    {
        [Display(Name = "收件人")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string Name { get; set; }// 收件人

        [Display(Name = "收件人地址")]
        [Required(ErrorMessage = "收件人地址不能为空")]
        public string Address { get; set; }// 收件人地址    

        [Display(Name = "电话")]
        [Required(ErrorMessage = "收件人电话不能为空")]
        public string MobilNumber { get; set; }//收件人电话号码

        [Display(Name = "头像")]
        [DataType (DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }
    }
}