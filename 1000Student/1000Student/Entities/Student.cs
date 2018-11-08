using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Student.Entities
{
    public class Student
    {
        public Guid ID { get; set; }
        public string StudentNo { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string FullName { get; set; }
        public bool Sex { get; set; } = true;
        public DateTime BirthDay { get; set; } = DateTime.Parse("1998-01-01");
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual DepartMent DepartMent { get; set; }
        public Student()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
