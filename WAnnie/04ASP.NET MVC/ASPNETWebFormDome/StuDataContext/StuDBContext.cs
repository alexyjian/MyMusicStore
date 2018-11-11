
using StuEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuContext
{
  public  class StuDBContext : DbContext
    {
        public DbSet<DepartMent> Departments { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
