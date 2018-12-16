using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.ViewModels
{
    public class MyViewModel
    {
        [Display(Name = "")]
        public string Name { get; set; }
        [Display(Name = "")]
        public string Address { get; set; }
        [Display(Name = "")]
        public bool Sex { get; set; }
        public string MobiNumber { get; set; }
        [Display(Name = "")]
        [DataType(DataType.Upload)]
        public  HttpPostedFileBase Avarda { get; set; }
    }
}