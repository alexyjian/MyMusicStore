using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CodeFirstModels
{
    public class Course
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public int Credit { get; set; }

        public virtual Department Department { get; set; }

        public Course()
        {
            ID = Guid.NewGuid();
        }
    }
}
