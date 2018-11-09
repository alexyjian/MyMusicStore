using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class DepartmentSeed
    {
        public static void Seed(StuDBContext context, string name, string dscn, string sortcode)
        {
            var p1 = new Department()
            {
                Name = name,
                DSCN = dscn,
                SortCode = sortcode
            };
            context.Departments.Add(p1);
        }
    }
}
