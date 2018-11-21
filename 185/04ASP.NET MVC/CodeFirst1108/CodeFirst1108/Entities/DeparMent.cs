using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.Entities
{
  public   class DeparMent
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public string Description { get; set; }
        public DeparMent()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
