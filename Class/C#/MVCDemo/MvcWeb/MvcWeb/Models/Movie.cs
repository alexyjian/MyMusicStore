using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeb.Models
{
    public class Movie
    {
        //编号
        public Guid ID { get; set; }

        //电影名
        public string Title { get; set; }

        //上映时间
        public DateTime ReleaseDate { get; set; }

        //分类
        public string Genre { get; set; }

        //价格
        public decimal Price { get; set; }

        public Movie()
        {
            ID = Guid.NewGuid();
            ReleaseDate = DateTime.Now;
        }
    }
}