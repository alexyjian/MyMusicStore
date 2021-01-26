using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Migrations
{
    public class UserAndRoleSeed
    {
        static readonly MusicStoreEntity.MusicContext _dbMusicContext = new MusicStoreEntity.MusicContext();

        /// <summary>
        /// 添加角色
        /// </summary>
        public static void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name = "Admin",
                DisplayName = "超级管理员组",
                Description = "最高权限",
                SortCode = "0",
                ApplicationRoleType = ApplicationRoleType.适用于系统管理人员
            };
            var role2 = new ApplicationRole()
            {
                Name = "Manger",
                DisplayName = "管理员组",
                Description = "一般权限",
                SortCode = "1",
                ApplicationRoleType = ApplicationRoleType.适用于有管理权限用户
            };
            var role3 = new ApplicationRole()
            {
                Name = "User",
                DisplayName = "用户组",
                Description = "注册用户",
                SortCode = "2",
                ApplicationRoleType = ApplicationRoleType.适用于一般注册用户
            };
            idManger.CreateRole(role1);
            idManger.CreateRole(role2);
            idManger.CreateRole(role3);

        }

        public static void AddUsers()
        {
            var idManger = new IdentityManager();

            var p1 = new Person()
            {
                FirstName = "S",
                LastName = "hroud1",
                Name = "Shroud1",
                CredentialsCode = "4545454545454545",
                Birthday = DateTime.Parse("2000-1-1"),
                Sex = true,
                MobileNumber = "1111111",
                Email = "Shroud@shroud.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "123456",
                Description = "超管",
                UpdateTime = DateTime.Now,
                InquiryPassword = "Git",
            };
            var loginUser = new ApplicationUser()
            {
                FirstName = "S",
                LastName = "hroud",
                UserName = "Shroud",
                Email = "Shroud@shroud.com",
                MobileNumber = "1111111",
                ChineseFullName = "帅",
                Person = p1
            };
            //密码大于6位,字母数字特殊符号
            idManger.CreateUser(loginUser, "admin.1");
            idManger.AddUserToRole(loginUser.Id, "Admin");

        }
    }
}