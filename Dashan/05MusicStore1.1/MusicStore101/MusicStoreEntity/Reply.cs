using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    //添加试听实体
    public class Reply
    {
        public Guid ID { get; set; }

        //标题
        [Display(Name = "标题")]
        public virtual string Title { get; set; }
        //内容
        [Display(Name = "内容")]
        [Required]
        public virtual string Content { get; set; }
        //用户
        [Required]
        public virtual Person Person { get; set; }
        //专辑
        [Required]
        public virtual Album Album { get; set; }
        //上级回复
        
        public virtual Reply ReplyPlaries { get; set; }
        //回复时间

        public DateTime MusicPlayTime { get; set; }
 
        //点赞 
        public int Like { get; set; } = 0;
      
        public int hate { get; set; } = 0;

        public Reply()
        {
            ID = Guid.NewGuid();
            MusicPlayTime = DateTime.Now;
        }
    }
}
