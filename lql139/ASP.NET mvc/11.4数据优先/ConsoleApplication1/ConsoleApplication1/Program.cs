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
            var context = new CourseDBEntities();
            var course = context.Courses.ToList();
            foreach (var c in course)
            Console.WriteLine("课程名称：{0},课程学分：{1},所属学院：{2}",c.Title,c.Credit,c.Departments.Name);
           
            ////添加--------------------
            //var newcour = new Courses()
            //{
            //    ID = Guid.NewGuid(),
            //    Title = "软件工程项目",
            //    Credit = 17,
            //    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            //};
            //context.Courses.Add(newcour);
            //context.SaveChanges();
            //var course1 = context.Courses.ToList();
            //foreach (var c in course1)
            //    Console.WriteLine("课程名称：{0},课程学分：{1},所属学院：{2}", c.Title, c.Credit, c.Departments.Name);
            
            ////修改--------------------
            //var updetecourse = context.Courses.SingleOrDefault(x => x.Title == "软件工程项目");
            //if (updetecourse != null)
            //{
            //    updetecourse.Title = "软件工程大大大项目";
            //    updetecourse.Credit = 4;
            //    context.SaveChanges();
            //}
            //else
            //{ Console.WriteLine("未找到记录"); }

            //foreach (var c in course)
            //    Console.WriteLine("课程名称：{0},课程学分：{1},所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            ////删除
            //var deletecourse=context.Courses.SingleOrDefault(x => x.Title == "软件工程大大大项目");
            //context.Courses.Remove(deletecourse);
            //context.SaveChanges();
            //foreach (var c in course)
            //    Console.WriteLine("课程名称：{0},课程学分：{1},所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            Console.ReadKey();
         


        }
    }
    }

