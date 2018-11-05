using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
    /// <summary>
    /// 学生实体
    /// </summary>
   public class Student
    {
        public Guid ID { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual Dopartment Dopartment { get; set; }

        public Student()
        {
            ID = Guid.NewGuid();
        }
    }
}
