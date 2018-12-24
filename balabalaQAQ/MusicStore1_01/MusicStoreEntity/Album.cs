﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 专辑
    /// </summary>
    public class Album
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        //所属分类
        public virtual Genre Genre { get; set; }
        //分类的主键值
        public string GenreID { get; set; }
        //歌手
        public virtual Artist Artist { get; set; }
        //歌手的主键值
        public string ArtistID { get; set; }
        //上架时间
        public DateTime PublisherDate { get; set; }

        //专辑的网址
        public string AlbumArtUrl { get; set; }

         
        public virtual ICollection<Reply> Reply { get; set; }

        //试听网址
        public string MusicUrl { get; set; } = "/music/1.mp3";
        public Album()
        {
            Price = 5;
            ID = Guid.NewGuid();
            PublisherDate = DateTime.Now;
        }
    }
}
