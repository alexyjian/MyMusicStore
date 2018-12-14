using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class PerAddress
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "收件人不能为空")]
        [Display(Name = "收件人")]
        public string AddressPerson { get; set; }//收件人


        [Required(ErrorMessage = "收货地址不能为空")]
        [Display(Name = "收货地址")]
        public string Address { get; set; }//收件人地址

        [Required(ErrorMessage = "电话不能为空")]
        [Display(Name = "收件人电话")]
        public string MobiNumber { get; set; }//收件人的手机

     
        public PerAddress()
        {
            ID = Guid.NewGuid();
        }

    }
   
}
