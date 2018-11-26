using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class UserAndRoleSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext_dbContext =new MusicStoreEntity.EntityDbContex();

            /// <summary>
            /// 
            /// </summary>
            public void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRlole()
            {
                Name = "Admin",
                DisplayName = "超级管理员",
                Description = "最高级权限角色",
                sortCode ="001",
                ApplicationRloleType = ApplicationRloleType.适用于系统管理人员
            };
            var role2 = new ApplicationRlole()
            {
                Name = "Manger",
                DisplayName = "一般管理组",
                Description = "一般管理权限的角色",
                sortCode = "002",
                ApplicationRloleType = ApplicationRloleType.适用于有管理权限用户
            };
            var role3 = new ApplicationRlole()
            {
                Name = "RegisterUser",
                DisplayName = "注册用户组",
                Description = "注册",
                sortCode = "003",
                ApplicationRloleType = ApplicationRloleType.适用于一般管理
            };
            idManger.CreateRole(role1);
            idManger.CreateRole(role2);
            idManger.CreateRole(role3);
        }

        public static void AddUsers()
        {
            var idManger = new IdentityManager();
            #region 管理员
            var person1 = new Person()
            {
                FirstName = "梅",
                LastName = "花",
                Name = "梅花",
                CredentialsCode = "4500545100041477",
                Birthday = DateTime.Parse("2015-01-01"),
                Sex =true,
                MobileNumber ="1775623465",
                Email ="messi@163.com",
                CreateDateTime =DateTime.Now,
                TelephoneNumber ="3157788",
                Description ="超级管理员",
                UpdateTime =DateTime.Now,
                InquiryPassword ="123456",
            };
        }
    }
}