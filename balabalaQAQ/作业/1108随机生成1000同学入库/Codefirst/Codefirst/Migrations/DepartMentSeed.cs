using Codefirst.DataContext;
using Codefirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codefirst.Migrations
{
    public class DepartMentSeed
    {
        public static void Seed(StuDBContext context)
        {
            var d1 = new DepartMent()
            {
                Name = "电子信息工程学院",
                Dscn = "222",
                SortCode = "1"

            };
            var d2 = new DepartMent()
            {
                Name = "机电工程学院",
                Dscn = "202",
                SortCode = "2"

            };
            var d3 = new DepartMent()
            {
                Name = "汽车工程学院",
                Dscn = "250",
                SortCode = "3"

            };
            var d4 = new DepartMent()
            {
                Name = "财经与物流学院",
                Dscn = "600",
                SortCode = "4"

            };
            context.DepartMents.Add(d1);
            context.DepartMents.Add(d2);
            context.DepartMents.Add(d3);
            context.DepartMents.Add(d4);
        }
       
    }
}
