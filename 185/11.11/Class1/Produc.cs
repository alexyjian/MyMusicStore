using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class1
{
   public  class Produc
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Sn { get; set; }
        public string DSCN { get; set; }
        public virtual Category Categoty { get; set; }
        public Produc()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
