using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefirst.Entities
{
    public class DepartMent
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Dscn { get; set; }
        public string SortCode { get; set; }

        public DepartMent()
        {
            ID = Guid.NewGuid(); 
        }
    }
}
