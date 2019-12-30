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
        public virtual Reply Reply { get; set; }
        public bool IsNotLike { get; set; }
        public virtual Person Person { get; set; }
        public DateTime CreateDateTime { get; set; }
        public LikeReply()
        {
            ID = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
