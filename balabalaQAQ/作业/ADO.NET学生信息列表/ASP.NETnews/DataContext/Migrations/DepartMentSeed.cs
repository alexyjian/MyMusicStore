using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataContext
{
    public class DepartMentSeed
    {

        public static void Seed(StuDBContext context)
        {
            var d1 = new Department()
            {
                Name = "电子信息工程学院",
                Dscn = "222",
                SortCode = "1"

            };
            var d2 = new Department()
            {
                Name = "机电工程学院",
                Dscn = "202",
                SortCode = "2"

            };
            var d3 = new Department()
            {
                Name = "汽车工程学院",
                Dscn = "250",
                SortCode = "3"

            };
            var d4 = new Department()
            {
                Name = "财经与物流学院",
                Dscn = "600",
                SortCode = "4"

            };
            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.Departments.Add(d4);
        }
    }
}
