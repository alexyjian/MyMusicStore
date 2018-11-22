using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo1.Models
{
    public class Moive
    {
        public Guid ID { get; set; }
        public string Titile { get; set; }
        //上映时间
        public DateTime ReleaseDate { get; set; }
        //电影类别
        public string Genre { get; set; }
        //价格
        public decimal Price { get; set; }

        public Moive()
        {
            ID = Guid.NewGuid();
            ReleaseDate = DateTime.Now;
        }
    }
}