using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntity
{
    //使用带用户认证权限机制的实体框架
    public class MusicContext : IdentityDbContext<ApplicationUser>
    {
        //调用基类的构造函数
        public MusicContext() : base("MusicContext") { }
        public static MusicContext Create()
        {
            return new MusicContext();
        }

        #region 用户与角色的实体

        public IDbSet<ApplicationInformation> ApplicationInformations { get; set; }
        public IDbSet<ApplicationBusinessType> ApplicationBusinessTypes { get; set; }
        public IDbSet<ApplicaitionUserInApplication> ApplicaitionUserInApplications { get; set; }
        public IDbSet<Person> Persons { get; set; }

        #endregion

         
        #region  音乐商店实体

        public IDbSet<Genre> Genres { get; set; }  // 音乐分类
        public IDbSet<Artist> Artists { get; set; } // 添加歌手
        public IDbSet<Ablum> Ablums { get; set; } // 添加专辑
        public IDbSet<Cart> Carts { get; set; } //购物车


        public IDbSet<Order> Orders { get; set; }  // 订单实体
        public IDbSet<OrderDetail> OrderDetails { get; set; }  // 订单明细
        public IDbSet<Reply> Replys { get; set; } //评论
        public IDbSet<LikeReply> LikeReplies { get; set; } //点赞或踩

        #endregion
    }
}
