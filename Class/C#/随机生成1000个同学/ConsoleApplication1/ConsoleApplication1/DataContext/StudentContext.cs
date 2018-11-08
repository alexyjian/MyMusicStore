using ConsoleApplication1.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Migrations
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
