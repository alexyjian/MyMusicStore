using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018._11._4_EF代码优先作业
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用数据上下文进行数据操作，using表示上下文代码的范围，执行完后内存会自动释放
            using (var context = new CourseContext())
            {
                var departments = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dsen);

                //Console.WriteLine("修改记录");
                //Console.WriteLine("===================================");

                ////修改
                //var editDepartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品检测学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "007";
                //    context.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到该记录，不能修改！");

                //Console.WriteLine("删除记录");
                //Console.WriteLine("===================================");
                ////find--用主键查询实体
                //var delDept = context.Departments.Find(Guid.Parse("fa0d71e5-6d49-4bd3-b079-d2df53b5a711"));
                ////var id = Guid.Parse("fa0d71e5-6d49-4bd3-b079-d2df53b5a711");
                ////var delDept = context.Departments.SingleOrDefault(x => x.ID == id);
                //context.Departments.Remove(delDept);
                //context.SaveChanges();


                Console.WriteLine("添加记录");
                Console.WriteLine("===================================");
                var newDepartment = new Departments
                {
                    ID = Guid.NewGuid(),
                    Name = "测试学院",
                    Dsen = "啦啦啦",
                    SortCode = "066"
                };
                //把新的对象记录添加到上下文中
                context.Departments.Add(newDepartment);
                //更新上下文，把新的的实体保存到数据库中
                context.SaveChanges();


                //显示新的记录
                var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments1)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dsen);
                Console.ReadKey();
            }
        }
    }
}
