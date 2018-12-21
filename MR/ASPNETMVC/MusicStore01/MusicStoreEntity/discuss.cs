using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    /// <summary>
    /// 评论的实体
    /// </summary>
    public class discuss
    {
        public Guid ID { get; set; }
        //通过用户ID去检索评论人的信息
        public Guid personID { get; set; }
        //确定好在哪个专辑下评论
        public Guid albumID { get; set; }
        //评论时间
        public DateTime discussTime { get; set; }
        //评论的内容
        public string discussData { get; set; }
        //回复的ID，如果为空，则正常评论
        public Guid replyID { get; set; }

        public discuss()
        {
            ID = Guid.NewGuid();
            discussTime = DateTime.Now;
        }
    }
}
