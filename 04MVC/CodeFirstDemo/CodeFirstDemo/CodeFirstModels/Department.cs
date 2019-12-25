using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
    /// <summary>
    /// 二级学院
    /// </summary>
    public class Department
    {
        //实体的主键，属性的命名规则:ID id 类名+ID 类名+id
        public Guid ID { get; set; }
        //学院名称
        public string Name { get; set; }
        //描述
        public string Description { get; set; }
        //排序码
        public string SortCode { get; set; }
        public Department()
        {
            ID = Guid.NewGuid();
        }
    }
}
