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
  public   class MusicContext: IdentityDbContext<ApplicationUser>
    {
        //调用基类的构造函数
        public MusicContext() : base("MusicContext") { }
        public static MusicContext Create()
        {
            return new MusicContext();
        }

        #region 用户与角色的实体

        public DbSet<ApplicationInformation> ApplicationInformations { get; set; }
        public DbSet<ApplicationBusinessType> ApplicationBusinessTypes { get; set; }
        public DbSet<ApplicaitionUserInApplication> ApplicaitionUserInApplications { get; set; }
        public DbSet<Person> Persons { get; set; }

        #endregion
}
}
