using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class LikeReply
    {
        public Guid ID { get; set; }

        public virtual Commentary Commentary { get; set; }

        public bool IsNotLike { get; set; }

        public virtual Person Person { get; set; }

        public LikeReply()
        {
            ID = Guid.NewGuid();
        }
    }
}
