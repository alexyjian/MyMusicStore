using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.CodeFirstModels
{
   public class Department
    {
        /// <summary>
        /// 二级学院实体
        /// </summary>
        //主键
        public Guid ID { get; set; }
        //学院名称
        public string Name { get; set; }
        //说明
        public string Description { get; set; }
        //排序码
        public string SortCode{ get; set; }
        public Department()
        {
            ID = Guid.NewGuid();
        }
    }
}
