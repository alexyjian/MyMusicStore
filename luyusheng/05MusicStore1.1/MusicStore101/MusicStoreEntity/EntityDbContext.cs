using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
   public class EntityDbContext:IdentityDbContext<ApplicationUser>
    {
        public EntityDbContext() : base("EntityDbContext") { }
        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }

        #region 用户与角色的实体
        public IDbSet<ApplicationIdformation> ApplicationIdformation { get; set; }
        public IDbSet<ApplicationBusinessType> ApplicationBusinessType { get; set; }
        public IDbSet<ApplicationUserInApplication> pplicationUserInApplication { get; set; }
        public IDbSet<Person> Person { get; set; }

    }
}