using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
  public  class Student
    {
        public Guid ID { get; set; }
        public string StudentNO { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool Sex { get; set; } = true;
        public DateTime BirthDay { get; set; }=DateTime.Parse("1998-12-30");
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual DepartMent  Department{ get; set; }
    public Student()
    {
        this.ID = Guid.NewGuid();
    }
        public string GetFullName()
        {
            this.FullName = this.FristName + this.LastName;
            return this.FullName;
        }
}
}
