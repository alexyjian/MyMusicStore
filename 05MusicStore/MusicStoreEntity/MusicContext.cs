﻿using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Album> Albums { get; set; }
        #endregion
    }
}