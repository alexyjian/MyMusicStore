using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class UserAndRoleSeed
    {
        private static readonly EntityDbContext _DBContext = new EntityDbContext();

        /// <summary>
        /// 权限组添加
        /// </summary>
        public static void AddUserAndRoles()
        {
            var idManager = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name = "Admin",
                DisplayName = "系统管理员组",
                Description = "系统管理员组",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于系统管理人员
            };
            idManager.CreateRole(role1);

            var role2 = new ApplicationRole()
            {
                Name = "Manager",
                DisplayName = "业务管理组",
                Description = "业务管理组",
                SortCode = "002",
                ApplicationRoleType = ApplicationRoleType.适用于有管理权限用户,
            };
            idManager.CreateRole(role2);

            var role3 = new ApplicationRole()
            {
                Name = "RegisterUser",
                DisplayName = "注册用户组",
                Description = "注册用户组",
                SortCode = "003",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户,
            };
            idManager.CreateRole(role3);
        }

        /// <summary>
        /// 特别用户添加
        /// </summary>
        public static void AddSpecialUser()
        {
            var idManager = new IdentityManager();

            #region 管理员用户

            var person1 = new Person()
            {
                FirstName = "管理员",
                LastName = "",
                Name = "管理员",
                CredentialsCode = "450101199001011111",
                Birthday = DateTime.Parse("1980-01-01"),
                Sex = true,
                MobileNumber = "13807728888",
                Email = "123@abc.cc",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "2628888",
                Description = "管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456"
            };
            var newUser = new ApplicationUser()
            {
                UserName = "messi",
                FirstName = "梅",
                LastName = "西",
                ChineseFullName = "梅西",
                MobileNumber = "13899998888",
                Email = "123@abc.cc",
                Person = person1
            };

            // 这里注意：创建的密码要满足响应的密码规则，否则将无法创建用户。
            idManager.CreateUser(newUser, "123.abc");
            idManager.AddUserToRole(newUser.Id, "Admin"); //添加到admin组

            #endregion 管理员用户

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
            idManager.CreateUser(newUser2, "123.abc");
            idManager.AddUserToRole(newUser2.Id, "RegisterUser");

            #endregion 注册用户

            #region 业务管理

            var person3 = new Person()
            {
                FirstName = "许",
                LastName = "生",
                Name = "许生",
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
                UserName = "chuping",
                FirstName = "许",
                LastName = "生",
                ChineseFullName = "许生",
                MobileNumber = "13899998888",
                Email = "646495830@qq.com",
                Person = person3
            };
            idManager.CreateUser(newUser3, "123.abc");
            idManager.AddUserToRole(newUser3.Id, "Manager");

            #endregion 业务管理
        }
    }
}