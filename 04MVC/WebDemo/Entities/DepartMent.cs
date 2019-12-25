using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class DepartMent
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        //描述
        public string Description { get; set; }
        //排序码
        public string SortCode { get; set; }
        public DepartMent()
        {
            ID = Guid.NewGuid();
        }
    }
}
