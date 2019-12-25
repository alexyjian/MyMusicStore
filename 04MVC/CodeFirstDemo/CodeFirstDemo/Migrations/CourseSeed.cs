﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
    public class CourseSeed
    {
        public static void Seed(CourseContext context)
        {
            var c1 = new Course()
            {
                Title = "C#程序设计",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c2 = new Course()
            {
                Title = "Web应用开发",
                Credit = 17,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c3 = new Course()
            {
                Title = "Mis开发实战",
                Credit = 7,
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var c4 = new Course()
            {
                Title = "工业制图",
                Credit = 4,
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var c5 = new Course()
            {
                Title = "发动机检测",
                Credit = 6,
                Department = context.Departments.SingleOrDefault(x => x.Name == "机电工程学院")
            };
            var c6 = new Course()
            {
                Title = "网络营销",
                Credit = 6,
                Department = context.Departments.SingleOrDefault(x => x.Name == "贸易与旅游学院")
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.Courses.Add(c4);
            context.Courses.Add(c5);
            context.Courses.Add(c6);
            context.SaveChanges();
        }
    }
}
