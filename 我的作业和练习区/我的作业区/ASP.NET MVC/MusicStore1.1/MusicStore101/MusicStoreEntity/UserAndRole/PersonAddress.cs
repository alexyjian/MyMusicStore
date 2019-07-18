using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity.UserAndRole
{
     public class PersonAddress
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        [Display(Name = "收件人")]
        [Required(ErrorMessage = "收件人不能为空。")]
        public string AddresPerson { get; set; }//收件人
        [Display(Name = "收件人地址")]
        [Required(ErrorMessage = "收件人地址不能为空。")]
        public string Address { get; set; }//收件地址
        [Display(Name = "收件人手机")]
        [Required(ErrorMessage = "收件人手机不能为空。")]
        public string MobileNumber { get; set; } // 手机号码
        public virtual Person persons { get; set; }

        public PersonAddress()
        {
            ID = Guid.NewGuid();
        }
    }
}
