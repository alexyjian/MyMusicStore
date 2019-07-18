using ConsoleApplication1.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Migrations
{
    public class DepartmentSeed
    {
        public static void Seed(CourseContext context,string name,string dscn,string sortCode)
        {
            var dt = new Department()
            {
                Name = name,
                DSCN = dscn,
                SortCode = sortCode
            };
            context.Departments.Add(dt);
        }
    }
}
