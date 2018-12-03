using Microsoft.AspNet.Identity;
using MusicStoreEntity.UserAndRole;

namespace MusicStoreEntities.UserAndRole
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}