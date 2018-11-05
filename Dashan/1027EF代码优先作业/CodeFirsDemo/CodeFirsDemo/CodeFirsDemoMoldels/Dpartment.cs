using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirsDemo
{
    /// <summary>
    /// 二级院校
    /// </summary>
  public  class Dpartment
    {
        //实体主键
        public Guid ID { get; set; }
        // 学院名称
        public string Name { get; set; }
        //说明
        public string Description { get; set; }
        //排序
        public string SortCode { get; set; }
        public Dpartment()
        {
            ID = Guid.NewGuid();
        }

    }
}
