using MucicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{
    internal class UserManager<T>
    {
        private UserStore<ApplicationUser> userStore;

        public UserManager(UserStore<ApplicationUser> userStore)
        {
            this.userStore = userStore;
        }
    }
}