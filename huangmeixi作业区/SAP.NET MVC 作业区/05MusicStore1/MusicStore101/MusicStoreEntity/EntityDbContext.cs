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
    public class EntityDbContext : IdentityDbContext<ApplicationUser>
    {
        //调用基类的构造函数
        public EntityDbContext() : base("EntityDbContext") { }
        public static EntityDbContext Create()
        {
            return new EntityDbContext();
        }


        public IDbSet<ApplicationInformation> ApplicationInformations { get; set; }
        public IDbSet<ApplicationBusinessType> ApplicationBusinessTypes { get; set; }
        public IDbSet<ApplicaitionUserInApplication> ApplicaitionUserInApplications { get; set; }
        public IDbSet<Person> Persons { get; set; }
    }
}
