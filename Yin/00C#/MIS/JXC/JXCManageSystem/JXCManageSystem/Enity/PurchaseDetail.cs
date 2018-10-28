using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enity
{
    public class PurchaseDetail
    {
        public int PurchaseID { get; set; }
        public int PurchaseDetailID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SortCode { get; set; }

        public string Serialnumber { get; set; }  //流水号 在显示时使用
        public string ProductName { get; set; }  //商品名称
        public string BarCode { get; set; }   //商品条码

        public PurchaseDetail()
        {
        }
    }
}
