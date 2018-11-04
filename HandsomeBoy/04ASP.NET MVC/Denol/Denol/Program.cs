using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denol
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个数据的上下文，所有的表的实体都会在此上下文中
            //var context = new CourseDBEntities();
            //var departments = context.Departments.OrderBy(x=>x.SortCode).ToList();
            //var courses = context.Courses.OrderBy(x => x.ID).ToList();
            //foreach (var d in departments)
            //    Console.WriteLine("{0}:{1}", d.SortCode, d.Name);

            //foreach (var d in courses)
            //    Console.WriteLine("课程名称:{0},课程学分:{1}", d.Title, d.Credit);

            //Console.ReadKey();

            //查询记录
            using (var context = new CourseDBEntities())
            {
                // .where .orderby .tolist() 注意顺序

                //var departments = context.Departments.Where(n=>n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();

                //foreach (var d in departments)
                //{
                //    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                //}


                //Console.WriteLine("添加一条新纪录");
                //Console.WriteLine("----------------------------------------");
                //var newDepartment = new Department
                //{
                //    ID = Guid.NewGuid(),
                //    Name = "环境与食品学院",
                //    Dscn = "环境与食品检测",
                //    SortCode = "005"
                //};
                //context.Departments.Add(newDepartment);
                //context.SaveChanges();
                //var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                //foreach (var d in departments1)
                //{
                //    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                //}

                //修改
                //Console.Write("修改记录");
                //Console.WriteLine("----------------------------------------");

                //var editDcpartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品学院");
                //if (editDcpartment != null)
                //{
                //    editDcpartment.Name = "环境与食品检测学院";
                //    editDcpartment.SortCode = "007";
                //    context.SaveChanges();
                //}
                //else
                //{
                //    Console.Write("未找到该记录，不能不能修改");
                // }
                //    foreach (var d in departments1)
                //    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);

                //删除
                //Console.Write("删除记录");
                //Console.WriteLine("----------------------------------------");
                ////find--用主键查询实体
                //var delDept = context.Departments.Find(Guid.Parse("e54fbe5d-026f-46d5-8455-bd981e6b39c5"));
                //context.Departments.Remove(delDept);
                //context.SaveChanges();

                //foreach (var d in departments)
                //{
                //    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                //}
              //123123
                //查询

            }
            Console.ReadLine();

            //
        }
    }
}
