using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demol
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CourseDBEntities1())
            {
                //.where .orderby .tolis()注意调用的顺序
                var departments = context.Department.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号:{0},部门名称:{1},说明{2}",d.SortCode,d.Name,d.Dscn);
                Console.WriteLine("添加一条新的部门记录");
                //添加一条记录
                var newDepartment = new Department
                {
                    ID = Guid.NewGuid(),
                    Name ="环境与食品学院",
                    Dscn = "环境与食品检测",
                    SortCode ="007"
                };
                //把新的对象添加到上下文中
                context.Department.Add(newDepartment);
                //更新上下文，把新的实体保存到数据库中
                context.SaveChanges();
                //显示新的记录
                var departments1 = context.Department.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments1)
                    Console.WriteLine("编号:{0},部门名称:{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();
            }
        }
    }
}
