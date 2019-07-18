using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {
        //调用基类的构造函数
        public EntityDbContext() : base("EntityDbContext") { }
        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }

        #region 用户与角色的实体

        public IDbSet<ApplicationInformation> ApplicationInformations { get; set; }
        public IDbSet<ApplicationBusinessType> ApplicationBusinessTypes { get; set; }
        public IDbSet<ApplicaitionUserInApplication> ApplicaitionUserInApplications { get; set; }
        public IDbSet<Person> Persons { get; set; }

        #endregion



        public IDbSet<Genre> Genre { get; set; }
        public IDbSet<Artist> Artist { get; set; }
        public IDbSet<Album>Albums { get; set; }
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Reply> Replies { get; set; }
        public IDbSet<LikeReply> LikeReplys { get; set; }

        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }

    }
}
