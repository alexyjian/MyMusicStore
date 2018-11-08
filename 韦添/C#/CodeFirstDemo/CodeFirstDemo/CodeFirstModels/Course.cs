using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
   public class Course
    {

        public Guid ID { get; set; }


        public string Title { get; set; }

        public int Credit { get; set; } = 1;

        public virtual Department Department { get; set; }

        public Course()
        {
            ID = Guid.NewGuid();
        }
    }
}
