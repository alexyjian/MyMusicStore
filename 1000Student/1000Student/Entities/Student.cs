using _1000Student.DataContext;
using _1000Student.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Student.Entities
{
    public class Student
    {
        public Guid ID { get; set; }
        public string StudentNo { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string FullName { get; set; }
        public bool Sex { get; set; } = true;
        public DateTime BirthDay { get; set; } = DateTime.Parse("1998-01-01");
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual DepartMent DepartMent { get; set; }
        public Student()
        {
            this.ID = Guid.NewGuid();
            this.FullName = GetName.getRandomName();
            this.lastName = FullName.Substring(1 - 1, 1);
            this.FirstName = FullName.Replace(lastName, "");
            this.StudentNo = RandomStuNO();
            //this.DepartMent =new StuDBContext().context.Departments.SingleOrDefault(x => x.Name == department());
        }
       
        public string RandomStuNO()
        {
            Random ran = new Random();
            int i = ran.Next(310000, 319000);
            return "20170"+i.ToString();
        }
        //public string department()
        //{
        //    string l=null;
        //    Random ran = new Random();
        //    int i = ran.Next(0, 5);
        //    switch (i)
        //    {
        //        case 1:
        //            l = "电子信息工程学院";
        //            break;
        //        case 2:
        //            l = "机电工程学院";
        //            break;
        //        case 3:
        //            l = "汽车工程学院";
        //            break;
        //        case 4:
        //            l = "贸易与旅游学院";
        //            break;
        //        case 5:
        //            l = "财经与物流学院";
        //            break;
        //    }
        //    return l;
        //}
    }
}
