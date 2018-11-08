using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirt1108.Entities
{
   public class Student
    {
        public Guid ID { get; set; }
  
        public string StudentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime BirhDay { get; set; } = DateTime.Parse("1999-11-24");

        public string Address { get; set; }
        public bool Sex { get; set; }
        public string phone { get; set; }

        public Student() {
            this.ID = Guid.NewGuid();
        }
    }
}
