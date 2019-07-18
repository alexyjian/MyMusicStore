using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CodeFirstModels
{
    public class Department
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string DSCN { get; set; }

        public string SortCode { get; set; }

        public Department()
        {
            ID = Guid.NewGuid();
        }
    }
}
