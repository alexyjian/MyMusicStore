using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class InfoViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ChineseFullName { get; set; }

        public string MobileNumber { get; set; }

        public DateTime BrithDay { get; set; }

        public bool Sex { get; set; }
    }
}