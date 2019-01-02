using MusicStoreEntity.UserAndRole;
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
        public DateTime OrderDateTime { get; set; }//订单的时间
        [ScaffoldColumn(false)]
        public virtual Person Person { get; set; }//所属用户

        //[Required(ErrorMessage = " 收件人不能为空")]//必填
        //[Display(Name = "收件人")]//显示的中文名
        //public string AddressPerson { get; set; }//收件人

        //[Required(ErrorMessage = " 收货地址不能为空")]//必填
        //[Display(Name = "收货地址")]//显示的中文名
        //public string Address { get; set; }//收件人地址
        //[Required(ErrorMessage = " 手机不能为空")]//必填
        //[Display(Name = "手机")]//显示的中文名
        //public string MobiNumber { get; set; }//收件人的手机
        [ScaffoldColumn(false)]
        public decimal TotalPrice { get; set; }//总价
        [ScaffoldColumn(false)]
        public string TradeNo { get; set; }//支付流水号
        [ScaffoldColumn(false)]
        public bool PaySuccess { get; set; }//是否支付成功
        [ScaffoldColumn(false)]
     
        public virtual EnumOrderStatus EnumOrderStatus { get; set; } //订单状态
        //购买专辑明细,EF中的包含关系
        [ScaffoldColumn(false)]
        public virtual My Mys { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            ID = Guid.NewGuid();
            OrderDateTime = DateTime.Now;
            TradeNo = OrderDateTime.ToString("yyyMMddhhmmssffff");
        }
    }
}
