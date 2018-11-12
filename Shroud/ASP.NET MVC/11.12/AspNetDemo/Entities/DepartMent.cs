using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEntities
{
    public class DepartMent
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DepartMent()
        {
            ID = Guid.NewGuid();
        }
    }
}
