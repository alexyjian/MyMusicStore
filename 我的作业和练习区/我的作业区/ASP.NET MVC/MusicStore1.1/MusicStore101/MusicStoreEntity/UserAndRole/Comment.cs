using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity.UserAndRole
{
     public class Comment
    {
        public Guid ID { get; set; }
        public string CommentMain { get; set; }//评论内容
        public bool Fabulous { get; set; }//赞
        public  string FabulousCount { get; set; }//赞数
    }
}
