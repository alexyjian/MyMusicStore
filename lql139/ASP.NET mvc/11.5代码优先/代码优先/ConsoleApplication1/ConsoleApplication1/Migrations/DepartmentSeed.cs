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
        public static void Seed(CourseContext context)
        {
            //初始化学院数据
            var d1 = new Department()
            {
                Name = "电子信息工程学院",
                SortCode = "001",
                Description = "第一大学院"
            };
            var d2 = new Department()
            {
                Name = "汽车工程学院",
                SortCode = "002",
                Description = "第一大学院"
            };
            var d3 = new Department()
            {
                Name = "机电工程学院",
                SortCode = "003",
                Description = "第一大学院"
            };
            var d4 = new Department()
            {
                Name = "艺术学院",
                SortCode = "004",
                Description = "第一大学院"
            };
            context.Department.Add(d1);
            context.Department.Add(d2);
            context.Department.Add(d3);
            context.Department.Add(d4);
            context.SaveChanges();

        }
    }
}
