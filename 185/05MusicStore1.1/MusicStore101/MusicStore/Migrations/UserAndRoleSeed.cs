using MusicStoreEntities.UserAndRole;
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
        public static  void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name = "Admin",
                DisplayName = "超级管理员",
                Description = "最高权限的角色",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户
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
                Description = "注册用户角色",
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
                FirstName = "黄",
                LastName = "学",
                Name = "明",
                CredentialsCode = "450000002000030888",
                Birthday = DateTime.Parse("2000-03-08"),
                Sex = true,
                MobileNumber = "19191919191919",
                Email = "qazs@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "3158899",
                Description = "注册用户角色",
                UpdateTime = DateTime.Now,
                InquiryPassword = "pig",
            };
            var loginUser = new ApplicationUser()
            {
                UserName = "hxm",
                FirstName = "黄",
                LastName = "明",
                ChineseFullName = "黄明",
                MobileNumber = "19191919191919",
                Email = "qazs@163.com",
                Person = person1,
            };
            //缺省配置，密码要大于6位，字母数字特殊符号，否则不能创建用户
            idManger.CreateUser(loginUser, "123.abc");
            idManger.AddUserToRole(loginUser.Id, "RegisterUser");


            #endregion

            var person2= new Person()
            {
                FirstName = "丑",
                LastName = "东",
                Name = "西",
                CredentialsCode = "450000000321652288",
                Birthday = DateTime.Parse("2001-03-08"),
                Sex = true,
                MobileNumber = "62185121215",
                Email = "qzs@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "3154699",
                Description = "",
                UpdateTime = DateTime.Now,
                InquiryPassword = "pig",
            };
            var newuser = new ApplicationUser()
            {
                UserName = "cdx",
                FirstName = "东",
                LastName = "西",
                ChineseFullName = "东西",
                MobileNumber = "62185121215",
                Email = "qzs@163.com",
                Person = person2,
            };
            idManger.CreateUser(newuser, "123.abc");
            idManger.AddUserToRole(newuser.Id, "RegisterUser");
        }
    }
}