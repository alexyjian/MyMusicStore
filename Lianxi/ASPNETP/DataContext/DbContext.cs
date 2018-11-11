using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;
namespace DataContext
{
    public class DbContext:System.Data.Entity.DbContext
        {
        public DbSet<category> Categories { get; set; }
        public DbSet<Prpduct> Puoducts { get; set; }
   
    }
}
