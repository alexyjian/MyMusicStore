
using StuContext;
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
        public DbSet<DopartMent> DepartMents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
