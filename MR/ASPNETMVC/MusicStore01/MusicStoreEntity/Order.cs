using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [ScaffoldColumn(false)]
        public Guid ID { get; set; }
        //订单的时间
        [ScaffoldColumn(false)]
        public DateTime OrderDateTime { get; set; }
        public virtual Person Person { get; set; }


        [Display(Name = "收件人")]
        [Required(ErrorMessage = "收件人不能为空")]
        public string AddressPerson { get; set; }
        [Display(Name = "地址")]
        [Required(ErrorMessage = "收货地址不能为空")]
        public string Address { get; set; }
        [Display(Name = "手机")]
        [Required(ErrorMessage = "手机号不能为空")]
        public string MobilNumber { get; set; }

        [ScaffoldColumn(false)]
        public decimal TotalPrice { get; set; }
        [ScaffoldColumn(false)]
        public string TradeNo { get; set; }
        [ScaffoldColumn(false)]
        public bool PaySuccess { get; set; }//是否支付成功


        [ScaffoldColumn(false)]
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
