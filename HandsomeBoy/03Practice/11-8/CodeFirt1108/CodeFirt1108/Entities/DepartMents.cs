using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirt1108.Entities
{
   public class DepartMents
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }

        public string Description { get; set; }
        public DepartMents()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
