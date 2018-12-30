using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 保存点赞和踩的实体
    /// </summary>
    public class LikeReply
    {
        public Guid ID { get; set; }

        public virtual Reply Reply { get; set; }

        public bool IsNotLike { get; set; }//like保存为true  hate保存为false


        public virtual Person Person { get; set; }


        public DateTime CreateDateTime { get; set; }

        public LikeReply()
        {
            ID = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
