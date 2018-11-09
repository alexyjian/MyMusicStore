using StuEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuContext
{
   public class StuDBContext:DbContext
    {
        public DbSet<DepartMent> DepartMent { get; set; }

        public DbSet<Studetnt> Studetnt { get; set; }

       
    }

}
