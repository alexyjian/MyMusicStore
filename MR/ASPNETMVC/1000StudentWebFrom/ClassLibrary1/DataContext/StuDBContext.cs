using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _1000Student.Entities;

namespace _1000Student.DataContext
{
    public class StuDBContext:DbContext
    {
		public DbSet<DepartMent> DepartMents { get; set; }
		public DbSet<Student> Students { get; set; }
    }
}
