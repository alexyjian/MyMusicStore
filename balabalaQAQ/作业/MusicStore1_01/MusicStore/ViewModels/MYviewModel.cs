using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class MYviewModel
    {
        [Display(Name ="姓名")]
        [Required(ErrorMessage ="姓名不能为空")]
        public string Name { get; set; }

        [Display(Name = "电话")]
        [Required(ErrorMessage = "电话不能为空")]
        public string MobileNumber { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "性别不能为空")]
        public bool Sex { get; set; }

        [Display(Name = "生日")]
        [Required(ErrorMessage = "生日不能为空")]
        public DateTime Birthday { get; set; }

        [Display(Name = "头像")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Avarda { get; set; }
    }
}