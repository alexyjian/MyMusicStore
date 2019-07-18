using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    //用来挂实体
    public class StuDBContext:DbContext
    {
        public DbSet<DepartMent> DepartMents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
