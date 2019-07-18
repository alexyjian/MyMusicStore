using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据上下文进行数据操作，using不是上下文代码的范围，执行完后内存就会自动释放
            using (var context = new CourseDBEntities())
            { 
                var departments = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.WriteLine("添加一条新的部门的记录");
                //添加一条记录
                var newDepartment = new Departments
                {
                    ID = Guid.NewGuid(),
                    Name = "环境与食品学院",
                    Dscn = "环境与食品检测",
                    SortCode="008"
                 
                
                };

                //把新的对象添加到上下文
                context.Departments.Add(newDepartment);
                //更新上下文，把新的实体保存到数据库中
                context.SaveChanges();

                //显示新的记录
                var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments1)
                    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);

                Console.ReadKey();
            }
        }
    }
}