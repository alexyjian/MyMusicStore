using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class PeopleAddress
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "收件人不能为空")]
        [Display(Name = "收件人")]
        public string Name { get; set; }//收件人

        [Required(ErrorMessage = "联系电话不能为空")]
        [Display(Name = "联系电话")]
        public string MobileNumber { get; set; }//联系手机

        [Required(ErrorMessage = "收件地址不能为空")]
        [Display(Name = "收件地址")]
        public string Address { get; set; }//收件地址

        public virtual Person Person { get; set; }

        public PeopleAddress()
        {
            ID = Guid.NewGuid();
        }
    }
}
