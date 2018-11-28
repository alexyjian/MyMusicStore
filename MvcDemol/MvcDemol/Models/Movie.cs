using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemol.Models
{
    public class Movie
    {
        public Guid ID { get; set; }
        public string Titile { get; set; }
        public DateTime ReleaseDate { get; set; }  //上映时间
        public string Gebre { get; set; }  //电影类别
        public decimal price { get; set; }  //价格
    }
}