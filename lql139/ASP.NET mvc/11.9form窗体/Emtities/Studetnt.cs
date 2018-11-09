using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuEntities
{
   public class Studetnt
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; } = true;
        public string Phone { get; set; }
        public string StudentNo { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public virtual DepartMent DepartMent { get; set; }

        public Studetnt()
        {
            ID = Guid.NewGuid();
        }
    }
}
