using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class Reply
    {
        public Guid ID { get; set; }
        
        public string Content { get; set; }//评论内容

        public virtual Person Person { get; set; }//所属用户

        public virtual Album Album { get; set; }//所属专辑

        public DateTime ReplyTime { get; set; }//评论时间

        //public virtual Reply ParentReply { get; set; }   //上级回复

       // public DateTime CreateDateTime { get; set; }  //回复时间
        public Reply() {
            ID = Guid.NewGuid();
            ReplyTime = DateTime.Now;
        }
    }
}
