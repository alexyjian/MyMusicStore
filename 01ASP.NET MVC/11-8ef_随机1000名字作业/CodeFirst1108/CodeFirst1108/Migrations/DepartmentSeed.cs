using CodeFirst1108.DataContext;
using CodeFirst1108.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.Migrations
{
   public class DepartmentSeed
    {
        public static void Seed (StuDBContext context)
        {
            var stu1 = new DepartMent()
            {
                Name="电子信息工程学院",
                Description="电子信息工程学院",
                SortCode="001",
            };

            var stu2 = new DepartMent()
            {
                Name = "汽车工程学院",
                Description = "汽车工程学院",
                SortCode = "002",
            };
            var stu3 = new DepartMent()
            {
                Name = "贸易与旅游学院",
                Description = "贸易与旅游学院",
                SortCode = "003",
            };
            var stu4 = new DepartMent()
            {
                Name = "机电工程学院",
                Description = "机电工程学院",
                SortCode = "004",
            };
            var stu5 = new DepartMent()
            {
                Name = "外语学院",
                Description = "外语学院",
                SortCode = "005",
            };
            context.DepartMent.Add(stu1);
            context.DepartMent.Add(stu2);
            context.DepartMent.Add(stu3);
            context.DepartMent.Add(stu4);
            context.DepartMent.Add(stu5);
            context.SaveChanges();
        }
    }
}
