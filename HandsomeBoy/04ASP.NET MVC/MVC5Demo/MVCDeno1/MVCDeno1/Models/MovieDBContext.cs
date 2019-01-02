using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVCDeno1.Models
{
    public class MovieDBContext:DbContext
    {
       public DbSet<Movie> Movies { get; set; }

    }
}