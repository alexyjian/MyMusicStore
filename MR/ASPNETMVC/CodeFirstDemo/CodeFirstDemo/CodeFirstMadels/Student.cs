using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstMadels
{
    public class Student
    {
        public Guid ID { get; set; }
        //学号
        public string StudentCode { get; set; }
        //姓名
        public string Name { get; set; }
        //性别
        public bool Sex { get; set; } = true;
        //生日
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        //手机号
        public string Phone { get; set; }
        public virtual Department Department { get; set; }

        public Student()
        {
            ID = Guid.NewGuid();
        }
    }
}
