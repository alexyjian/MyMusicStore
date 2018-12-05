using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo1.Models
{
    public class Movie
    {
        public Guid ID { get; set; }//zhujian
        public string Titile { get; set; }
        public DateTime ReleaseDate { get; set; }//上映时间

         public string Genre { get; set; }//

        public decimal Price { get; set; }

        public Movie()
        {
            ID = Guid.NewGuid();
            ReleaseDate = DateTime.Now;
        }
    }
}