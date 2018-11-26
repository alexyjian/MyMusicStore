using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreWeb.Migrations
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
                FirstName = "袁",
                LastName = "宝宝",
                Name = "袁宝宝",
                CredentialsCode = "458796541235987456",
                Birthday = DateTime.Parse("2016-06-06"),
                Sex = true,
                MobileNumber = "15879654131",
                Email = "messi@163.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "6698743",
                Description = "超级管理员",
                UpdateTime = DateTime.Now,
                InquiryPassword = "123456",
            };
            var longinUser = new ApplicationUser()
            {
                UserName = "messi",
                FirstName = "袁",
                LastName = "宝宝",
                ChineseFullName = "袁宝宝",
                MobileNumber = "15879654131",
                Email = "messi@163.com",
                Person = person1,
            };
            //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
            idManger.CreateUser(longinUser, "123.abc");
            //添加到Admin角色
            idManger.AddUserToRole(longinUser.Id, "Admin");
            #endregion
        }
    }
}