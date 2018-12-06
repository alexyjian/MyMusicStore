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
                Name = "Admin",
                DisplayName = "超级管理组",
                Description = "最高权限的角色",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于系统管理人员
            };

            var role2 = new ApplicationRole()
            {
                Name = "Manger",
                DisplayName = "一般管理组",
                Description = "一般管理权限的角色",
                SortCode = "002",
                ApplicationRoleType = ApplicationRoleType.适用于有管理权限用户
            };

            var role3 = new ApplicationRole()
            {
                Name = "RegisterUser",
                DisplayName = "注册用户组",
                Description = "用户注册的角色",
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
            #region 超级管理员
            var person1 = new Person()
            {
                FirstName = "梅",
                LastName = "西",
                Name = "梅西",
                CredentialsCode = "45020320010203101X",
                Birthday = DateTime.Parse("2000-02-03"),
                MobileNumber = "15277245068",
                Email = "messi@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "3158899",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456"
            };

            var loginUser = new ApplicationUser()
            {
                UserName = "messi",
                FirstName = "梅",
                LastName = "西",
                ChineseFullName = "梅西",
                MobileNumber = "15277245068",
                Email = "messi@163.com",
                Person = person1
            };

            idManger.CreateUser(loginUser, "123.abc");
            idManger.AddUserToRole(loginUser.Id, "Admin");
            #endregion
            #region 一般管理员
            var person2 = new Person()
            {
                FirstName = "晓",
                LastName = "钰",
                Name = "覃晓钰",
                CredentialsCode = "450205200006015048",
                Birthday = DateTime.Parse("2000-06-01"),
                MobileNumber = "18954762513",
                Email = "qty@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "3158899",
                Description = "一般管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456"
            };

            var loginUser2 = new ApplicationUser()
            {
                UserName = "qty",
                FirstName = "晓",
                LastName = "钰",
                ChineseFullName = "覃晓钰",
                MobileNumber = "18954762513",
                Email = "qty@163.com",
                Person = person2
            };

            idManger.CreateUser(loginUser2, "123.abc");
            idManger.AddUserToRole(loginUser2.Id, "Manger");
            #endregion
            #region 用户注册
            var person3 = new Person()
            {
                FirstName = "刘",
                LastName = "熊",
                Name = "刘晓熊",
                CredentialsCode = "450201199810010001",
                Birthday = DateTime.Parse("1998-10-01"),
                MobileNumber = "13978015456",
                Email = "lxx@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "13978015456",
                Description = "用户注册",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456"
            };

            var loginUser3 = new ApplicationUser()
            {
                UserName = "lxx",
                FirstName = "刘",
                LastName = "熊",
                ChineseFullName = "刘晓熊",
                MobileNumber = "13978015456",
                Email = "lxx@163.com",
                Person = person3
            };

            idManger.CreateUser(loginUser3, "123.abc");
            idManger.AddUserToRole(loginUser3.Id, "RegisterUser");
            #endregion
        }
    }
}