using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music.ViewModels
{
    public class DetailReply
    {
        public Guid ID { get; set; }//专辑ID
        public string Title { get; set; }
        public decimal Price { get; set; }
        //所属分类
        public DateTime PublisherDate { get; set; }
        public string AlbumArtUrl { get; set; }
        public string MusicUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public string Replys { get; set; }
    }
}