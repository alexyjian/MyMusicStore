using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirstModels
{
  public  class Department
    {
        //实体主键命名规则ID.id类名+Id/类名+id
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
