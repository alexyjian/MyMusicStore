using SEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDataContext
{
    public class StudentContent:DbContext
    {
        public DbSet<DepartMent> DepartMents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
