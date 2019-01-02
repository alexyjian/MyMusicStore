using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enity
{
    /// <summary>
    /// 商品分类的实体
    /// </summary>
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category() { }
        public Category(int categoryID,string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }
    }
}
