using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order
    {
        public Guid ID { get; set; }
        //订单的时间
        public DateTime OrderDateTime { get; set; }
        public virtual Person Person { get; set; }
        public string AddressPerson { get; set; }

        public string Address { get; set; }
        public string MobilNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public string TradeNo { get; set; }
        public bool PaySuccess { get; set; }//是否支付成功


        public virtual EnumOrderStatus EnumOrderStatus { get; set; }
        //购买专辑明细
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            ID = Guid.NewGuid();
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");
        }
    }
}
