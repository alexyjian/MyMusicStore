using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
  public  class Albun
    {
        public Guid ID { get; set; }
        public string Title { get; set; }//专辑名称
        public decimal Price { get; set; }
        //所属分类
        public virtual Genre Genre { get; set; }
        //分类主键
        public string GenreId { get; set; }
        //歌手
        public virtual Artist Artist{ get; set; }
        //歌手主键
        public string ArtistId { get; set; }
        //上架时间
        public DateTime PublsherDate { get; set; }

      
        public string AlbumArtUrl { get; set; }
        public Albun() {
            ID = Guid.NewGuid();
            PublsherDate = DateTime.Now;
        }

    }
}
