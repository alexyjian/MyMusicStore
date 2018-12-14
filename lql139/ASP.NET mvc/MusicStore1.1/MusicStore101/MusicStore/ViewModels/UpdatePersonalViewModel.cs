using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class UpdatePersonalViewModel
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "电话号码不能为空")]
        [Display(Name = "电话号码")]
        public string MobileNumber { get; set; }


        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }
    }
}