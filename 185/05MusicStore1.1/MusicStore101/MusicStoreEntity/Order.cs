using MusicStoreEntities.UserAndRole;
using MusicStoreEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public  class Order
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public virtual Person Person { get; set; }
        [Display(Name ="收件人")]
        [Required(ErrorMessage="收件人不能为空")]
        public string AddressPerson { get; set; }
        [Display(Name = "收件人地址")]
        [Required(ErrorMessage = "收件人地址不能为空")]
        public string Address { get; set; }
        [Display(Name = "手机")]
        [Required(ErrorMessage = "手机不能为空")]

        public string MobilNumber { get; set; }
        public decimal TotalPrice { get; set; }
        [ScaffoldColumn(false)]
        public string TradeNo { get; set; }
        public bool PaySuccess { get; set; }
        [ScaffoldColumn(false)]
        public virtual EnumOrderStatus EnumOrderStatus {get; set; }
        [ScaffoldColumn(false)]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            ID = Guid.NewGuid();
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");
            
        }
    }
     
}
