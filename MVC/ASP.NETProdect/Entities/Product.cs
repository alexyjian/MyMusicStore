using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SN { get; set; }
        public string DSCN { get; set; }
        public virtual Category Category { get; set; }
        public Product()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
