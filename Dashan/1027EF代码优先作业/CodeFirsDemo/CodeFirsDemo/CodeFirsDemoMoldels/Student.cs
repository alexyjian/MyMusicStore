using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirsDemo.CodeFirsDemoMoldels
{

    /// <summary>
    /// 学生实体
    /// </summary>
   public class Student
    {
        public Guid ID { get; set; }
        public string StudentCode { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
       
    }
}
