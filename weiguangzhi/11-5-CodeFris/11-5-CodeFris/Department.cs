using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5_CodeFris
{
    /// <summary>
    /// 二级学院
    /// </summary>
    public class Department
    {
        //实体主键，属性的命名规则：ID id类名+ID、类名+id
        public Guid ID { get; set; }
        //学院名称
        public string Name { get; set; }
        //说明
        public string Desciption { get; set; }
        //排序码
        public string SortCode { get; set; }
        public Department()
        {
            ID = Guid.NewGuid();
        }

    }
}
