using CodeFirst1108.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1108.DateContext
{
   public  class StuDBContext:DbContext
    {
        public  DbSet<DeparMent>DepartMents { get; set; }

        public DbSet<Studetnt> Students { get; set; }
    }
}
