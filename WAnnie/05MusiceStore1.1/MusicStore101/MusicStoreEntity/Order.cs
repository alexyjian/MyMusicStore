using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntity
{
 public   class Order
    {
        /// <summary>
        /// 订单实体
        /// </summary>
        public Guid ID { get; set; }
        //订单时间
        public DateTime OrderDateTime { get; set; }
        //所属用户
        public virtual Person Person { get; set; }
        //收件人
        public string AddressPerson { get; set; }
        //收件人地址
        public string Address { get; set; }
        //收件人手机
        public string MobilNumber { get; set; }
        //总价
        public decimal TotalPrice { get; set; }
        //支付宝流水号
        public  string TradeNo { get; set; }
        //是否支付成功
        public bool PaySuccess { get; set; }

        //订单状态
        public  virtual EnumOrderStatus EnumOrderStatus { get; set; }

        //购买专辑明细,EF中的包含关系
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            ID=Guid.NewGuid();
            OrderDateTime=DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");
        }

    }
}
