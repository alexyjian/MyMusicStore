using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000Student.Entities
{
    public class DepartMent
    {
        //学院卡号
        public Guid ID { get; set; }
        //学院名
        public string Name { get; set; }
        public string SortCode { get; set; }
        public string Description { get; set; }
        public DepartMent()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
