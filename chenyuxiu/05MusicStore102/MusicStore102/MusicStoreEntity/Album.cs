﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
  public   class Album
    {
       public Guid ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public virtual Genre Genre { get; set; }
        public  string GenreId { get; set; }
        public virtual Artist  Artist { get; set; }
        public string ArtisId { get; set; }
        public DateTime PublisherData { get; set; }
        public  string AlbumArtUrl { get; set; }
        public Album()
        {
            ID = Guid.NewGuid();
            PublisherData = DateTime.Now;
        }

    }
}