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
        public int Count { get; set; }
        public DateTime CareateDate{ get; set; }
        public virtual Album Album { get; set; }
        public string AblumID { get; set; }
        public virtual Person Person { get; set; }


        public Cart()
        {
            ID = Guid.NewGuid();
            CareateDate = DateTime.Now;
        }

    }
}
