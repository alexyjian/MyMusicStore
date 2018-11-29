using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore101.Migrations
{
    public class UserAndRoleSeed
    {
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
                Name = "Manger",
                DisplayName = "一般管理员组",
                Description = "一般权限管理的角色",
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
        public static void AddUser()
        {
            var idManger = new IdentityManager();

            var person1 = new Person()
            {
                FirstName = "梅",
                LastName = "西",
                Name = "梅西",
                CredentialsCode = "546444654646464",
                Birthday = DateTime.Parse("2015-01-01"),
                Sex = true,
                MobileNumber = "12346978",
                Description="超级管理员",
                Email = "meissi@1qq.com",
                CreateDateTime = DateTime.Now,
                TelephoneNumber = "1324679",

            };

            var loginUser = new ApplicationUser()
            {
                UserName = "messi",
                FirstName = "梅",
                LastName = "西",
                ChineseFullName = "梅西",
                MobileNumber = "21346579",
                Email = "messi@qq.com",
                Person = person1,
                     
            };
            //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
            idManger.CreateUser(loginUser, "123.abc");
            //添加到Admin角色
            idManger.AddUserToRole(loginUser.Id, "Admin");
        }
    }
  
}