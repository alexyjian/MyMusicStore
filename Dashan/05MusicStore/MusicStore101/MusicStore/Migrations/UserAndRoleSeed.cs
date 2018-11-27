using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
   public static class UserAndRoleSeed
    {
        private static readonly MusicStoreEntity.EntityDbContexts _dbContext = new MusicStoreEntity.EntityDbContexts();

        /// <summary>
        /// 添加角色
        /// </summary>
        public static void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name = "Admin",
                DisplayName = "超级权限的角色",
                Description = "最高权限的角色",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于系统管理人员

            };
            var role2 = new ApplicationRole()
            {
                Name = "Manager",
                DisplayName = "一般管理组",
                Description = "一般管理权限的角色",
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
            var idManager = new IdentityManager();
            #region 管理员
            var person1 = new Person()
            {
                FirstName = "流",
                LastName = "川枫",
                Name = "流川枫",
                CredentialsCode = "4528201998060256370",
                Birthday = DateTime.Parse("1998-6-2"),
                Sex = true,
                MobileNumber = "17429811300",
                Email = "liuchuanfen@178.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "48438939",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            #endregion

            #region 注册用户
            var person2 = new Person()
            {
                FirstName = "章",
                LastName = "若楠",
                Name = "章若楠",
                CredentialsCode = "4528202001060256370",
                Birthday = DateTime.Parse("2001-06-02"),
                Sex = false,
                MobileNumber = "17720811300",
                Email = "zhangRn@188.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "480309390",
                Description = "注册用户",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser2 = new ApplicationUser()
            {
                UserName = "zrn",
                FirstName = "章",
                LastName = "若楠",
                ChineseFullName = "章若楠",
                MobileNumber = "17720811300",
                Email = "zhangRn@188.com",
                Person = person2
            };
            idManager.CreateUser(newUser2, "123.abc");
            idManager.AddUserToRole(newUser2.Id, "RegisterUser");
            #endregion

            #region 业务管理
            var person3 = new Person()
            {
                FirstName = "陈",
                LastName = "奕迅",
                Name = "陈奕迅",
                CredentialsCode = "4528201990160256370",
                Birthday = DateTime.Parse("1990-16-02"),
                Sex = false,
                MobileNumber = "17720811355",
                Email = "ChenYx@198.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "570309370",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser3 = new ApplicationUser()
            {
                UserName = "cyx",
                FirstName = "陈",
                LastName = "奕迅",
                ChineseFullName = "陈奕迅",
                MobileNumber = "17720811355",
                Email = "ChenYx@198.com",
                Person = person3
            };
            idManager.CreateUser(newUser3, "123.abc");
            idManager.AddUserToRole(newUser3.Id, "Manager");
            #endregion
        }
    }
}
