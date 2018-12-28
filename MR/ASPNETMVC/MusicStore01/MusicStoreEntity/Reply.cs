using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 回复
    /// </summary>
    public class Reply
    {
        public Guid ID { get; set; }

        [Display(Name = "标题")]
        public virtual string Title { get; set; }

        [Display(Name = "内容")]
        [Required]
        public virtual string Content { get; set; }

        [Required]
        public virtual Person Person { get; set; }

        [Required]
        public virtual Album Album { get; set; }

        public virtual Reply ParentReply { get; set; }   //上级回复

        public DateTime CreateDateTime { get; set; }  //回复时间

        //赞
        public int Like { get; set; } = 0;

        //黑
        public int Hate { get; set; } = 0;

        public Reply()
        {
            ID = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }
    }
}
