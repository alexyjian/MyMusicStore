using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MusicStoreEntity.UserAndRole;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicStoreEntity
{
    //使用带用户认证权限机制的实体框架
    public class MusicContext : IdentityDbContext<ApplicationUser>
    {
        
        //用户与角色的实体

        public IDbSet<ApplicationInformation> ApplicationInformations { get; set; }
        public IDbSet<ApplicationBusinessType> ApplicationBusinessTypes { get; set; }
        public IDbSet<ApplicaitionUserInApplication> ApplicaitionUserInApplications { get; set; }
        public IDbSet<Person> Persons { get; set; }

       
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Artist> Artists { get; set; }


        //调用基类的构造函数
        public MusicContext() : base("MusicContext") { }
        public static MusicContext Create()
        {
            return new MusicContext();
        }
    }
}
