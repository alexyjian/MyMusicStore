using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVCDemo1.Models
{
    public class MovieDBContext:DbContext
    {
        public DbSet<Moive> Moives { get; set; }
        
    }
}