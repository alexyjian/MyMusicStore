using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity.Migrations
{
    public class UserAndRoleSeed
    {
        private static readonly MusicStoreEntity.EntityDbContext _dbContext=new MusicStoreEntity.EntityDbContext();

        public static void AddRoles()
        {
            var idManger = new IdentityManager();
            var role1 = new ApplicationRole()
            {
                Name = "Admin",
                DisplayName = "cj",
                Description = "lh",
                SortCode = "001",
                ApplicationRoleType = ApplicationRoleType.适用于系统管理人员
            };
            var role2 = new ApplicationRole()
            {
                Name = "Manger",
                DisplayName = "yb",
                Description = "cj",
                SortCode = "002",
                ApplicationRoleType = ApplicationRoleType.适用于有管理权限用户
            };
            idManger.CreateRole(role1);
            idManger.CreateRole(role2);


        }
        public static void AddUsers()
        {
            var idManager = new IdentityManager();
            #region 管理员
            var person1 = new Person()
            {
                FirstName = "梅",
                LastName = "西",
                Name = "梅西",
                CredentialsCode = "4500002015010112345",
                Birthday = DateTime.Parse("2015-01-01"),
                Sex = true,
                MobileNumber = "13833883388",
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
                ChineseFullName = "梅西",
                MobileNumber = "13833883388",
                Email = "messi@163.com",
                Person = person1,
            };
            //缺省配置，密码大于6位，字母数字特殊符号，否则不能创建用户
            idManager.CreateUser(loginUser, "123456");
            //添加到Admin角色
            idManager.AddUserToRole(loginUser.Id, "Admin");
            #endregion
        }



    }
}
