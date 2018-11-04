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
            using (var cotext = new CourseDBEntities())
            {
                var departments = cotext.Departments.Where(n => n.Name.Contains("工程")).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();

                Console.WriteLine("添加一条新的部门记录");
                //添加一条新的记录
                var newDepartment = new Departments
                {
                    ID = Guid.NewGuid(),
                    Name = "环境与食品学院",
                    Dscn = "环境与食品学院",
                    SortCode = "007"
                };
                //把新的对象添加到上下中
                cotext.Departments.Add(newDepartment);
                cotext.SaveChanges();
                //显示新的记
                var departments1 = cotext.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();
            }

        }
    }
}
