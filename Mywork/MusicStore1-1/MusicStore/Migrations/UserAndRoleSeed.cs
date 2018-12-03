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
                Name = "Manager",
                DisplayName = "一般管理员",
                Description = "一般管理权限的角色",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于有管理权限用户
            };
            var role3 = new ApplicationRole()
            {
                Name = "RegisterUser",
                DisplayName = "注册用户组",
                Description = "注册用户角色",
                SortCode = "001",
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
                FirstName = "黄",
                LastName = "影儿",
                Name = "黄影儿",
                CredentialsCode = "450221200011223698",
                Birthday = DateTime.Parse("2000-11-22"),
                Sex = true,
                MobileNumber = "15252525252",
                Email = "yinger@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "5522522",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "456789",
            };
            var loginUser = new ApplicationUser()
            {
                UserName = "Baiguia",
                FirstName = "覃",
                LastName = "哦哦",
                ChineseFullName = "覃哦哦",
                MobileNumber = "15252525252",
                Email = "yinger@163.com",
                Person = person1,
            };
            
            //缺省配置 密码要大于6位 字母数字特殊符号 否则不能创建用户
            idManger.CreateUser(loginUser, "123.abc");
            idManger.AddUserToRole(loginUser.Id, "Admin");
            #endregion

            #region 注册用户

            var person2 = new Person()
            {
                FirstName = "黄",
                LastName = "生",
                Name = "黄生",
                CredentialsCode = "452222198210090011",
                Birthday = DateTime.Now,
                Sex = false,
                MobileNumber = "13899998888",
                Email = "978798821@qq.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "80861688",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser2 = new ApplicationUser()
            {
                UserName = "hs",
                FirstName = "黄",
                LastName = "生",
                ChineseFullName = "黄生",
                MobileNumber = "13899998888",
                Email = "978798821@qq.com",
                Person = person2
            };
            idManger.CreateUser(newUser2, "123.abc");
            idManger.AddUserToRole(newUser2.Id, "RegisterUser");

            #endregion 注册用户

            #region 业务管理

            var person3 = new Person()
            {
                FirstName = "许",
                LastName = "生生",
                Name = "许生生",
                CredentialsCode = "452222198210090011",
                Birthday = DateTime.Parse("1980-01-01"),
                Sex = true,
                MobileNumber = "13899998888",
                Email = "646495830@qq.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "2621688",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser3 = new ApplicationUser()
            {
                UserName = "xs",
                FirstName = "许",
                LastName = "生生",
                ChineseFullName = "许生生",
                MobileNumber = "13899998888",
                Email = "646495830@qq.com",
                Person = person3
            };
            idManger.CreateUser(newUser3, "123.abc");
            idManger.AddUserToRole(newUser3.Id, "Manager");

            #endregion 业务管理
        }

    }
}
