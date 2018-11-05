using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CodeFirstModels
{
   public class student
    {
        public Guid ID { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set;}
        public string ADDdress { get; set; }
        public string Phone { get; set; }
        public bool Sex { get; set; }

        public virtual Department Department { get; set; }
        public student()
        {
            ID = Guid.NewGuid();
        }
    }
}
