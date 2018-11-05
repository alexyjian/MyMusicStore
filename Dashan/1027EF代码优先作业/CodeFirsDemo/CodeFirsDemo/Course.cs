using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirsDemo.CodeFirsDemo
{
    /// <summary>
    /// 课程实体
    /// </summary>
   public class Course
    {
        public Guid ID { get; set; }
        //课程名称
        public string Title { get; set; }
        //学分
        public int Credit { get; set; } = 1;
        //用外键实体 自定义的类作为属性
        public virtual Dpartment Dpartment { get; set; }

        public Course()
        {
            ID = Guid.NewGuid();
        }
        
    }
}
