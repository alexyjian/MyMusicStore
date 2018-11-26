using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class UseAndRoleSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext_dbContext new MusicStoreEntity.EntiyDbContext();
            ///添加角色
           public void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                name = "Asmin",
                IDisplayName = "超级管理员",
                Description = "最高级权限角色",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户
            };
            var role2 = new ApplicationRole()
            {
                name = "Manger",
                IDisplayName = "一般管理员",
                Description = "一般管理权限角色",
                SortCode = "002",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户
            };
            var role3 = new ApplicationRole()
            {
                name = "RegisterUser",
                IDisplayName = "注册用户组",
                Description = "注册用户组的角色",
                SortCode = "003",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户
            };
            idManger.CreateRole(role1);
            idManger.CreateRole(role2);
            idManger.CreateRole(role3);
        }
        public void AddUsers()
        {
            var idManger = new IdentityManager();
            #region 管理员
            var person1 = new Person()
            {
                FirtName = "梅",
                LastName = "西",
                CredentialsCode = "450000000201501012345",
                Birthday = DateTime.Parse("2015-01-01"),
                Sex = true,
                MobilieNumber = "12345678914",
                Email = "messi@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "3158899",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var loginUser = new ApplicationUser()
            {
                UserName = "messi",
                FirstName = "梅",
                LastName = "西",
                ChainesFullName = "梅西",
                MobileNumber = "13833883388",
                Email = "messi@163.com",
                Person = person1,
            };
            //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
            idManger.CreateUser(loginUser, "123.abc");
            //添加到Admin角色
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
                UserName = "xs",
                FirstName = "许",
                LastName = "生",
                ChineseFullName = "许生",
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