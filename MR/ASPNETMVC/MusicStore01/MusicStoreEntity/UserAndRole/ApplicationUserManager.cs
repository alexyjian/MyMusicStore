using Microsoft.AspNet.Identity;
using MusicStoreEntity;
using UserAndRole;

namespace MusicStoreEntity.UserAndRole
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}