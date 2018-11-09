using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuEntities
{
    public class DopartMent
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }

        public DopartMent()
        {
            ID = Guid.NewGuid();
        }
    }
}
