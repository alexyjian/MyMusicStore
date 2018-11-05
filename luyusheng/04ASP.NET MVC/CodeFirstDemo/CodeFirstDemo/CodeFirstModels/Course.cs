using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
    /// <summary>
    /// 课程实体
    /// </summary>
   public class Course
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public int Credit { get; set; } = 1;
        public virtual Dopartment Dopartment{ get; set; }

        public Course()
        {
            ID = Guid.NewGuid();
        }
    }
}
