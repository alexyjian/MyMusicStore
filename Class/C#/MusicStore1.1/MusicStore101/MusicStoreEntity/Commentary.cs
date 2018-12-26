using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class Commentary
    {
        public Guid ID { get; set; }

        //内容
        public string Context { get; set; }

        //时间
        public DateTime PublisherDate { get; set; }

        //评论人
        public virtual Person Person { get; set; }

        //评论歌曲
        public virtual Album Album { get; set; }

        public int ThumbsUp { get; set; } = 0;

        public virtual Commentary commentary { get; set; }

        public Commentary()
        {
            ID = Guid.NewGuid();
            PublisherDate = DateTime.Now;
        }
    }
}
