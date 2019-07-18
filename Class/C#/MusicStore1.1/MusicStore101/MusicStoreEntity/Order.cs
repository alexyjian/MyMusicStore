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
        public Guid ID { get; set; }

        //订单时间
        public DateTime OrderDateTime { get; set; }

        //所属用户
        public virtual Person Person { get; set; }

        //收件人
        public string AddressPerson { get; set; }

        //收件地址
        public string Address { get; set; }

        //收件人手机号码
        public string mobilNumber { get; set; }

        //总价
        public decimal TotalPrice { get; set; }

        //流水号
        public string TradeNo { get; set; }

        //是否支付成功
        public bool PaySuccess { get; set; }

        public virtual EnumOrderStatus EnumOrderStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual PeopleAddress PeopleAddress { get; set; }

        public Order()
        {
            ID = Guid.NewGuid();
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyyMMddhhmmssffff");
        }
    }
}
