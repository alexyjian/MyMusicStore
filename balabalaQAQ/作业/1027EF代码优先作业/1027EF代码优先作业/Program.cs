using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027EF代码优先作业
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var CourseDB = new CourseDBEntities())
            {
                var DB = new Courses
                {
                    ID = Guid.NewGuid(),
                    Title = "做作业",
                    Credit = "009",
                    Department_ID = Guid.Parse("a664af03-adcf-4311-b2d5-44c98264a5a0")
                };
                CourseDB.Courses.Add(DB);
            }
        }
    }
}
