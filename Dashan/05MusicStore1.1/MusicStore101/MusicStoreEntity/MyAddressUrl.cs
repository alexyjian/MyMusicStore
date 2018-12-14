using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public class MyAddressUrl
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }

        [Display(Name = "收件人姓名")]
        [Required(ErrorMessage = "收件人姓名不能为空")]
        public string AddressPerson { get; set; }// 收件人


        [Display(Name = "收件人地址")]
        [Required(ErrorMessage = "收件人地址不能为空")]
        public string Address {get;set;}// 收件人地址

        [Display(Name = "收件人电话")]
        [Required(ErrorMessage = "收件人电话号码不能为空")]
        public string MobilNumber { get; set; }//收件人电话号码
        public MyAddressUrl()
        {
            ID = Guid.NewGuid();
           
        }
    }
}
