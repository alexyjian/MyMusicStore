using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        [ScaffoldColumn(false)]
        public DateTime OrderDateTime { get; set; }//订单时间
        public virtual Person Person { get; set; }//所属用户
        [Display(Name ="收件人")]
        [Required(ErrorMessage ="收件人不能为空。")]
        public string AddressPerson { get; set; }//收件人
        public string Address{ get; set; }//收件人地址
        public string MobilNumber { get; set; }//收件人的手机
        [ScaffoldColumn(false)]
        public decimal TotalPrice { get; set; }//总价
        [ScaffoldColumn(false)]
        public string TradeNo { get; set; }//支付流水号
        [ScaffoldColumn(false)]
        public bool PaySuccess { get; set; }//是否支付成功

        public virtual EnumOrderStatus EnumOrderStatus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //购买专辑
        public Order()
        {
            ID = Guid.NewGuid();
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");

        }
    }
}
