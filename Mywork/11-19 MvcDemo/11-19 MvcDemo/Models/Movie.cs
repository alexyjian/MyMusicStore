using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _11_19_MvcDemo.Models
{
    public class Movie
    {
        public Guid ID { get; set; }
        public string Tite { get; set; }
        public DateTime ReLeaseDate { get; set;}
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public Movie()
        {
            ID = Guid.NewGuid();
            ReLeaseDate = DateTime.Now;
        }
    }
}