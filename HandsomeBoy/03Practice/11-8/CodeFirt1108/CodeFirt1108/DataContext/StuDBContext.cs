using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirt1108.Entities;

namespace CodeFirt1108.DataContext
{
   public class StuDBContext:DbContext
    {
        public DbSet<DepartMents> DepartMent { get; set; }
        public DbSet<Student> Studetnt { get; set; }
    }
}
