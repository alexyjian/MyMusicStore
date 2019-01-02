using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ConfirmTheOrderModel
    {
     

        public string AddressPerson { get; set; }//收件人
       
        public string Address { get; set; }//收件人地址

        
        public string MobiNumber { get; set; }//收件人的手机
    }
}