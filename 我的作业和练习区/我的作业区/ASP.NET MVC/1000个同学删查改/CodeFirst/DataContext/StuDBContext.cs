using Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class StuDBContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<DepartMent> DepartMents { get; set; }
    }
}
