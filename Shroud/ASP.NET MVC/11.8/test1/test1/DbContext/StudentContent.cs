using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.Code;

namespace test1.DbContent
{
    public class StudentContent:DbContext
    {
        public DbSet<DepartMent> DepartMents { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
