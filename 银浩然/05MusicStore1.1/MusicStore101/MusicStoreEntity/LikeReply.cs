using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntity
{
    /// <summary>
    /// 保存点赞或踩的实体
    /// </summary>
   public class LikeReply
    {
        public Guid ID { get; set; }
        public virtual Reply Reply { get; set; }//关联评论

        public virtual Person Person { get; set; }//关联用户
        public bool IsNoLike { get; set; }//like保存true hate保存false

        public DateTime CreateDataTime { get; set; }

        public LikeReply()
        {
            ID=Guid.NewGuid();
            CreateDataTime=DateTime.Now;
        }
    }
}
