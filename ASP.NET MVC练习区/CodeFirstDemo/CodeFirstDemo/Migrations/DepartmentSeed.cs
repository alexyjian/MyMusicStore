using CodeFirstDemo.CodeFirstModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Migrations
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
                Description = "天下第一"
            };
            var d2 = new Department()
            {
                Name = "机电工程学院",
                SortCode = "002",
                Description = "天下第二"
            };
            var d3 = new Department()
            {
                Name = "财经与物流工程学院",
                SortCode = "003",
                Description = "天下第三"
            };
            var d4 = new Department()
            {
                Name = "汽车工程学院",
                SortCode = "004",
                Description = "天下第四"
            };
            context.Departments.Add(d1);
            context.Departments.Add(d2);
            context.Departments.Add(d3);
            context.Departments.Add(d4);
            context.SaveChanges();
        }
    }
}
