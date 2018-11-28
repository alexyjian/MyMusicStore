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
                DisplayName = "超级管理员",
                Description = "最高级权限角色",
                SortCode = "001",
                ApplicationRoleType =ApplicationRoleType.适用于系统管理人员
            };
            var role2 = new ApplicationRole()
            {
                Name = "Manger",
                DisplayName = "一般管理组",
                Description = "一般管理权限的角色",
                SortCode = "002",
                ApplicationRoleType  = ApplicationRoleType.适用于有管理权限用户
            };
            var role3 = new ApplicationRole()
            {
                Name = "RegisterUser",
                DisplayName = "注册用户组",
                Description = "注册",
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
                FirstName = "梅",
                LastName = "花",
                Name = "梅花",
                CredentialsCode = "4500545100041477",
                Birthday = DateTime.Parse("2015-01-01"),
                Sex = true,
                MobileNumber = "1775623465",
                Email = "messi@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "3157788",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            
            var loginUser = new ApplicationUser()
            {
                UserName ="messi",
                FirstName = "梅",
                LastName = "花",
                ChineseFullName = "梅花",
                MobileNumber = "1775623465",
                Email = "messi@163.com",
                Person =person1,
            };
            //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
            idManger.CreateUser(loginUser, "123.abc");
            //添加到Admin角色
            idManger.AddUserToRole(loginUser.Id, "Admin");
            #endregion 管理员

            #region 注册用户
            var person2 = new Person()
            {
                FirstName = "李",
                LastName = "敏",
                Name = "李敏",
                CredentialsCode = "452284199501010044",
                Birthday = DateTime.Now,
                Sex = false,
                MobileNumber = "1775623478",
                Email = "77221467@qq.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "55681024",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser2 = new ApplicationUser()
            {
                UserName = "lm",
                FirstName = "李",
                LastName = "敏",
                ChineseFullName = "李敏",
                MobileNumber = "1775623465",
                Email = "77221467@qq.com",
                Person = person2,
            };
            idManger.CreateUser(newUser2, "123.abc");
            idManger.AddUserToRole(newUser2.Id, "RegisterUser");
            #endregion  注册用户

            #region 业务管理
            var person3 = new Person()
            {
                FirstName = "许",
                LastName = "宣",
                Name = "许宣",
                CredentialsCode = "452220199311155207",
                Birthday = DateTime.Parse("1980-11-25"),
                Sex = false,
                MobileNumber = "1775623478",
                Email = "12254778@qq.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "22156844",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var newUser3 = new ApplicationUser()
            {
                UserName = "xx",
                FirstName = "许",
                LastName = "宣",
                ChineseFullName = "许宣",
                MobileNumber = "1775623465",
                Email = "12254778@qq.com",
                Person = person3,
            };
            idManger.CreateUser(newUser3, "123.abc");
            idManger.AddUserToRole(newUser3.Id, "Manager");
            #endregion 业务管理
        }
    }
}