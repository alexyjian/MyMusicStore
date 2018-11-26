using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities
{
    public class Student
    {
        public Guid ID { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; } = true;
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual DepartMent DepartMent { get; set; }
        public Student()
        {
            ID = Guid.NewGuid();
        }
    }
}
