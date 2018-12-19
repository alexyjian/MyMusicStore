using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 专辑实体类
    /// </summary>
    public class Album
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        
        //所属分类
        public virtual Genre Genre { get; set; }
        //所属分类ID
        public string GenreID { get; set;}

        //所属歌手
        public virtual Artist Artist { get; set; }
        //所属歌手ID
        public string ArtistID { get; set; }

        public DateTime PublisherDate { get; set; }

        //专辑网址
        public string AlbumArtUrl { get; set; }

        //音乐地址
        public string MusicUrl { get; set; }

        public virtual ICollection<Commentary> Commentarys { get; set; }

        public Album()
        {
            ID = Guid.NewGuid();
            PublisherDate = DateTime.Now;
            Price = 0;
        }
    }
}
