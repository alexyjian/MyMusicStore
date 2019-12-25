using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class OrderDetail
    {
        public Guid ID { get; set; }
        public string AlbumID { get; set; }
        public virtual Album Album { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public OrderDetail()
        {
            ID = Guid.NewGuid();
        }
    }
}
