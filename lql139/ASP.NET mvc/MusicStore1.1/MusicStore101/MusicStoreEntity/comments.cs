using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public class Comments
    {
        public Guid ID { get; set; }

        public string content { get; set; }//评论内容

        public virtual Album Album { get; set; }

        public virtual Person Person { get; set; }

        public DateTime publisheddate { get; set; }

        [Required]
        public virtual Reply ParentReply { get; set; }

        public int Like { get; set; }//赞

        public int Hate { get; set; }//踩

        public Comments()
        {
            ID = Guid.NewGuid();
            publisheddate = DateTime.Now;
        }
    }
}
