using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CourseDBEntities())
            {
                var departments = context.Departments.OrderBy(n => n.Sortcode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.Sortcode, d.Name, d.Dscn);
                //添加--------------
                //var newDepartment = new Departments
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "环境与食品学院",
                //    Dscn = "环境食品检测",
                //    Sortcode = "005"
                //};
                //context.Departments.Add(newDepartment);
                //context.SaveChanges();
                //var departments1 = context.Departments.OrderBy(n => n.Sortcode).ToList();
                //foreach (var d in departments1)
                //    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.Sortcode, d.Name, d.Dscn);

                //修改--------------
                //var editDepartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    context.SaveChanges();////更新数据库
                //}
                //else { Console.WriteLine("未找到记录"); }
                //var departments1 = context.Departments.OrderBy(n => n.Sortcode).ToList();
                //foreach (var d in departments1)
                //    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.Sortcode, d.Name, d.Dscn);

                //删除--------------
                //var detdep = context.Departments.Find(Guid.Parse("c6c88ddb-8636-4d02-ba3c-7ca42818ec0b"));
                //context.Departments.Remove(detdep);
                //context.SaveChanges();

                //var departments1 = context.Departments.OrderBy(n => n.Sortcode).ToList();
                //foreach (var d in departments1)
                //    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.Sortcode, d.Name, d.Dscn);

                Console.ReadKey();
            }
        }
    }
}
