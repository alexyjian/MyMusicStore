using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntity
{
    /// <summary>
    /// 评论的实体
    /// </summary>
  public  class Reply
    {
        public Guid ID { get; set; }

        [Display(Name = "标题")]
        public virtual string Title { get; set; }

        [Display(Name = "内容")]
        [Required]
        public virtual string Content { get; set; }

        [Required]
        public virtual Ablum Ablum { get; set; }

        [Required]
        public  virtual Person Person { get; set; }

        //上级回复    
        public virtual Reply ParentReply { get; set; }


        //回复时间
        public DateTime CreateDateTime { get; set; }

        //赞
        public int Like { get; set; } = 0;
        //黑
        public int Hate { get; set; } = 0;
        public object ParetReply { get; set; }

        public Reply()
        {
            ID=Guid.NewGuid();
            CreateDateTime=DateTime.Now;
        }
    }
}
