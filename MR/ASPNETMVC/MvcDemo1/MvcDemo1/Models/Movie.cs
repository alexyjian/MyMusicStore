using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo1.Models
{
    /// <summary>
    /// 实体类
    /// </summary>
    public class Movie
    {
        public Guid ID { get; set; }
        public string Titile { get; set; }
        public DateTime ReleaseDate { get; set; }//上映的时间
        public string Genre { get; set; }//电影类别
        public decimal Price { get; set; }//票价

        public Movie()
        {
            ID = Guid.NewGuid();
            ReleaseDate = DateTime.Now;
        }
    }
}