using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcDemo1.Models
{
    public class MovieDBContext:DbContext
    {
        public DbSet<Movie> Moves { get; set; }
    }
}