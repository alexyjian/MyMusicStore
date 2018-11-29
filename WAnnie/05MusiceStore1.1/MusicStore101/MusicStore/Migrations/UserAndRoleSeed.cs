using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class UserAndRoleSeed
    {
        public static readonly MusicStoreEntity.MusicContext _dbContext = new MusicStoreEntity.MusicContext();

        //添加角色
        public static void AddRoles()
        {
          
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name = "Admin",
                DisplayName = "超级管理员组",
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
                FirstName = "张",
                LastName = "杰",
                Name = "张杰",
                CredentialsCode = "450000198212205923",
                Birthday = DateTime.Parse("1982-12-20"),
                Sex = true,
                MobileNumber = "13471892486",
                Email = "jason@1220.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "321838579",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var loginUser = new ApplicationUser()
            {
                UserName = "Jason",
                FirstName = "张",
                LastName = "杰",
                ChineseFullName = "张杰",
                MobileNumber = "13471892456",
                Email = "Jason@1220.com",
                Person = person1,
            };
            //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
            idManager.CreateUser(loginUser, "123.abc");
            //添加到Admin角色
            idManager.AddUserToRole(loginUser.Id, "Admin");
            #endregion

            #region 注册用户

            var person2 = new Person()
            {
                FirstName = "谢",
                LastName = "娜",
                Name = "谢娜",
                CredentialsCode = "45200019810506889",
                Birthday = DateTime.Now,
                Sex = false,
                MobileNumber = "1895324988",
                Email = "xiena@56.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "89799879",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser2 = new ApplicationUser()
            {
                UserName = "xn",
                FirstName = "谢",
                LastName = "娜",
                ChineseFullName = "谢娜",
                MobileNumber = "1895324988",
                Email = "xiena@56.com",
                Person = person2
            };
            idManager.CreateUser(newUser2, "123.abc");
            idManager.AddUserToRole(newUser2.Id, "RegisterUser");

            #endregion 注册用户

            #region 业务管理

            var person3 = new Person()
            {
                FirstName = "何",
                LastName = "炅",
                Name = "何炅",
                CredentialsCode = "45201331972112600",
                Birthday = DateTime.Parse("1972-11-26"),
                Sex = true,
                MobileNumber = "18975697598",
                Email = "1234567@qq.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "23586896",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser3 = new ApplicationUser()
            {
                UserName = "hj",
                FirstName = "何",
                LastName = "炅",
                ChineseFullName = "何炅",
                MobileNumber = "18975697598",
                Email = "1234567@qq.com",
                Person = person3
            };
            idManager.CreateUser(newUser3, "123.abc");
            idManager.AddUserToRole(newUser3.Id, "Manager");

            #endregion 业务管理
        }
    }
}