using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Class1;

namespace DataContext
{
    public class ProductDbContext : DbContext 
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Produc> Products { get; set; }
    }
}
