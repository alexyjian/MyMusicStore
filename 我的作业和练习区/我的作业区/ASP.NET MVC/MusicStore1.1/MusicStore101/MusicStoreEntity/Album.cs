using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 歌手信息
    /// </summary>
    public class Album
    {
        public Guid ID { get; set; }
        //专辑分类
        public string Title { get; set; }  
        public decimal Price { get; set; }
        //所属分类
        public virtual Genre Genre { get; set; }
        //分类的主键
        public string GenreId { get; set; }
        //歌手
        public virtual Artist Artist { get; set; }
        //歌手的主键值
        public string ArtistId { get; set; }
        //上架时间
        public DateTime PublisherDate { get; set; }
        public string AlbumArtUrl { get; set; }
        public string MusicUrl { get; set; } = "/music/1.mp3";
        public Album()
        {
            ID = Guid.NewGuid();
            PublisherDate = DateTime.Now;
        }
    }
}
