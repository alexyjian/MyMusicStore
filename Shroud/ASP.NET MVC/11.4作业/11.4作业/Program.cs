using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._4作业
{
    class Program
    {
        static void Main(string[] args)
        {
            //11.4
            using (var datacontent =new CoursesContent())
            {
                var coursesdata = datacontent.Courses.ToList();
                //var coursesdata = from data in datacontent.Courses select data;
                foreach (var d in coursesdata)
                {
                    Console.WriteLine("{0} / {1} /  {2}", d.Title, d.Credit,d.Department.SortCode);
                }
                var objCours = new Cours
                {
                    ID = Guid.NewGuid(),
                    Title = "test1",
                    Credit = 7,
                    Department_ID = datacontent.Departments.SingleOrDefault(x => x.Name=="电子信息工程").ID
                };
                datacontent.Courses.Add(objCours);

                //var delCourse = datacontent.Courses.Find(Guid.Parse("6cdc6850-3ae7-49f2-af24-7f93e81c0f56"));
                //datacontent.Courses.Remove(delCourse);

                var updateCourse = datacontent.Courses.Find(Guid.Parse("6cdc6850-3ae7-49f2-af24-7f93e81c0f56"));
                if(updateCourse!=null)
                updateCourse.Title = "test1update";
                datacontent.SaveChanges();
                Console.ReadKey();
            }

        }
    }
}
