﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_4EF代码优先级作业
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CourseDBEntities())
            {
               
                Console.WriteLine("没更改之前的查询");
                var courses = context.Courses.OrderBy(n => n.Credit).ToList();
                foreach (var c in courses)
                {
                    Console.WriteLine("课程名称{0},课程学分{1},所属学院{2}", c.Title, c.Credit,c.Departments.Name);
                }

                //添加一条新纪录
                var Newcourses = new Courses
                {
                    ID = Guid.NewGuid(),
                    Title = "数学",
                    Credit = 2,
                    Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
                };
                context.Courses.Add(Newcourses);
                context.SaveChanges();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("添加一条新纪录后的查询");

                foreach (var c in courses)
                {
                    Console.WriteLine("课程名称{0},课程学分{1}", c.Title, c.Credit,c.Departments.Name);
                }

                var courseUpdate = context.Courses.SingleOrDefault(x => x.Title == "商务英语");
                if (courseUpdate != null)
                {
                    courseUpdate.Title = "商务英语大学篇";
                    courseUpdate.Credit = 3;
                    context.SaveChanges();
                }
                else
                {
                    Console.Write("没有数据，无法更新");
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("更改一条新纪录后的查询");
                foreach (var c in courses)
                {
                    Console.WriteLine("课程名称{0},课程学分{1},所属学院{2}", c.Title, c.Credit, c.Departments.Name);
                }

             var deletecon =  context.Courses.Find(Guid.Parse("7fdf3c57-b50a-4305-b4b3-b3ba074bd0f3"));
                context.Courses.Remove(deletecon);
                context.SaveChanges();
              
            }
            Console.ReadKey();
        }
    }
}
