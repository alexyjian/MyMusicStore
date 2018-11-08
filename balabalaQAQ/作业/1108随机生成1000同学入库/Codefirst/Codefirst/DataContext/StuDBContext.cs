using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codefirst.Entities;
using System.Data.Entity;

namespace Codefirst.DataContext
{
    public class StuDBContext: DbContext
    {
        public DbSet<DepartMent> DepartMents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
