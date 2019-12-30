using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _11_19_MvcDemo.Models
{
    public class MovieDBContext:DbContext
    {
        public DbSet<Movie> Movie {get;set;}
    }
}