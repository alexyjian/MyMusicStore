using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class UserAndRoleSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext = new MusicStoreEntity.EntityDbContext();
        /// <summary>
        /// 添加角色
        /// </summary>
        public static void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name="Admin",
                DisplayName="超级管理员",
                Description="最高权限的角色",
                SortCode="001",
                ApplicationRoleType=ApplicationRoleType.适用于系统管理人员
            };
            var role2 = new ApplicationRole()
            {
                Name = "Manger",
                DisplayName = "一般管理员",
                Description = "一般权限的角色",
                SortCode = "002",
                ApplicationRoleType = ApplicationRoleType.适用于有管理权限用户
            };
            var role3 = new ApplicationRole()
            {
                Name = "RegisterUser",
                DisplayName = "注册用户组",
                Description = "注册用户的角色",
                SortCode = "003",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户
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
                FirstName = "仙",
                LastName = "人",
                Name = "仙人",
                CredentialsCode = "450204200002221415",
                Birthday = DateTime.Parse("2000-2-22"),
                Sex = true,
                MobileNumber = "12580",
                Email = "xianren@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber="10068",
                Description="超级管理员",
                UpdateTime=DateTime.Now,
                InquiryPassword="123456"
            };
            var loginUser = new ApplicationUser()
            {
                UserName="xianren",
                FirstName="仙",
                LastName="人",
                ChineseFullName="仙人",
                MobileNumber="12580",
                Email="xianren@163.com",
                Person=person1
            };

            idManger.CreateUser(loginUser,"123.abc");

            idManger.AddUserToRole(loginUser.Id,"Admin");
            #endregion
        }
    }
}