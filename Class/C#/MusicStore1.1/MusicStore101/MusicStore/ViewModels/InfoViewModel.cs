using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class InfoViewModel
    {
        [Required(ErrorMessage = "姓氏不能为空")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "姓氏不能为空")]
        public string LastName { get; set; }

        public string ChineseFullName { get; set; }

        [Required(ErrorMessage = "姓氏不能为空")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "姓氏不能为空")]
        public DateTime BrithDay { get; set; }

        public bool Sex { get; set; }

        public HttpPostedFileBase Avarda { get; set; }

        public InfoViewModel()
        {
            ChineseFullName = FirstName + LastName;
        }
    }
}