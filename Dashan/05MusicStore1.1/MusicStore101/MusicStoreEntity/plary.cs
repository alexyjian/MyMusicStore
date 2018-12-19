using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    //添加试听实体
   public  class plary
    {
        public Guid ID { get; set; }
        //标题
        public virtual string Title { get; set; }
        //内容
        public virtual string Content { get;set;}
       //用户
       public virtual Person Person { get; set; }
        //专辑
        public virtual Album Album { get; set; }
        //上级回复
        public virtual plary ReplyPlary { get; set;}
        //回复时间
        public virtual DateTime MusicPlayTime { get; set; }
        public plary()
        {
            ID = Guid.NewGuid();
            MusicPlayTime = DateTime.Now;

        }

    }
}
