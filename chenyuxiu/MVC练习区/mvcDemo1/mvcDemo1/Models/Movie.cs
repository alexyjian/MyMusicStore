using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcDemo1.Models
{
    public class Movie
    {
        public Guid ID { get; set; }
        public string  Title { get; set; }
        public DateTime ReleaseDate { get; set; } //上映时间
        public string Genre { get; set; }//电影类别
        public decimal Prce { get; set; }//价格

        public Movie()
        {
            ID = Guid.NewGuid();
            ReleaseDate = DateTime.Now;
        }
    } 
}