using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enity
{
    /// <summary>
    /// 产品的实体
    /// </summary>
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string SpellCode { get; set; }  //拼音码
        public string BarCode { get; set; }  //条码
        public string Special { get; set; }   //型号
        public string Unit { get; set; }  //计量单位
        public string Original { get; set; }  //产地
        public decimal PurchasePrice { get; set; }  //采购价格
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }  //加一个分类名称，方便查询

        public Product() 
        { }
    }
}
