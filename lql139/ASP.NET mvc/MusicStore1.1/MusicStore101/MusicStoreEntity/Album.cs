using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 歌曲
    /// </summary>
   public class Album
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }//专辑价格
        public virtual Genre Genre { get; set; }
        public string GenreID { get; set; }
        public virtual Artist Artist{ get; set; }
        public string ArtistID { get; set; }
        public DateTime PublisherDate { get; set; }
        public string AlbumArtUrl { get; set; }///专辑的网址
        public string MusicUrl { get; set; } = "/Music/1.mp3";
        public Album()
        {
            ID = Guid.NewGuid();
            PublisherDate = DateTime.Now;
        }
    }
}
