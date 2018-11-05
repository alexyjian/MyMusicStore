using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5test.CodefirstModels
{
    public class Student
    {
        public Guid ID { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public virtual Department Department { get; set; }
        public Student()
        {
            ID = Guid.NewGuid();
        }
    }
}
