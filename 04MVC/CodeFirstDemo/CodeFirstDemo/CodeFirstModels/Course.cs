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
        //课程名称
        public string Title { get; set; }
        //学分
        public int Credit { get; set; } = 1;
        public virtual Department Department { get; set; }
        public string CourseCode { get; set; }
        public int StudyPeriod { get; set; } = 0;
        public Course()
        {
            ID = Guid.NewGuid();
        }
    }
}
