using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
public     class Cart
    {
        public Guid ID { get; set; }
        public string CartID { get; set; }
        public int Count { get; set; } = 1;
        public DateTime CareateDate{ get; set; }
        public virtual Album Album { get; set; }
        public string AlbumID { get; set; }

        public virtual Person Person { get; set; }


        public Cart()
        {
            ID = Guid.NewGuid();
            CareateDate = DateTime.Now;
        }

    }
}
