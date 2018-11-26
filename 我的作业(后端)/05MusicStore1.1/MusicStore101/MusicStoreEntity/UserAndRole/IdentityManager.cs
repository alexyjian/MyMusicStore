using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MusicStoreEntity.UserAndRole
{
    /// <summary>
    /// 与系统用户标识认证配置相关的约束工具类
    /// </summary>
    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new EntityDBContext()));
            return rm.RoleExists(name);
        }

        public bool CreateRole(string name, string displayName)
        {
            var rm = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new EntityDBContext()));
            var role = new ApplicationRole() { Name = name, DisplayName = displayName };
            var idResult = rm.Create(role);
            return idResult.Succeeded;
        }

        public bool CreateRole(ApplicationRole role)
        {
            var rm = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new EntityDBContext()));
            var idResult = rm.Create(role);
            return idResult.Succeeded;
        }

        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDBContext()))
            {
                PasswordValidator = new PasswordValidator()
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false, //必须包含非字母或数字
                    RequireDigit = false,  //必须包含数字
                    RequireLowercase = false,  //必须包含小写字母
                    RequireUppercase = false  //必须包含大写字母
                }
            };
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }

        public bool CreateUser(ApplicationUser user, string password, EntityDBContext dbContext)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext))
            {
                PasswordValidator = new PasswordValidator()
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false
                }
            };
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDBContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDBContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.RoleId);
            }
        }

        public bool MapUserToPerson(ApplicationUser user, Person person)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EntityDBContext()));
            user.Person = person;
            var idResult = um.Update(user);
            return idResult.Succeeded;
        }

        public ApplicationRole GetRole(string roleName)
        {
            var rm = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new EntityDBContext()));
            var role = rm.FindByName(roleName);
            return role;
        }

        public List<ApplicationRole> GetRoleAll()
        {
            var results = new List<ApplicationRole>();
            var rm = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new EntityDBContext()));
            foreach (var item in rm.Roles)
                results.Add(item);

            return results;
        }
    }
}