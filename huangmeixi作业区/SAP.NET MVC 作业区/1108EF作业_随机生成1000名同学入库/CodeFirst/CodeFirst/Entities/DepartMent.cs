using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public   class DepartMent
    {
        public Guid iD { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public string Description { get; set; }
        public DepartMent()
        {
            this.iD = Guid.NewGuid();

        }

    }
}
