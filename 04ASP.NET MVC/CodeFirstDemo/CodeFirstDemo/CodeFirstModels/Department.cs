using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
    /// <summary>
    /// 二级学院的实体
    /// </summary>
    public class Department
    {
        //实体的主键，属性的命名规则:ID、Id、类名+ID、类名+Id
        public Guid ID { get; set; }
        //学院名称
        public string Name { get; set; } 
        //说明
        public string Description { get; set; }
        //排序码
        public string SortCode { get; set; }

        public Department()
        {
            ID = Guid.NewGuid();
        }
    }
}
