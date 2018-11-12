using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// 产品分类实体
    /// </summary>
    public class Category
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }

        public  Category()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
