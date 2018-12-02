using System;
using MusicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{
    internal class UserManger<T>
    {
        private UserStatus<ApplicationUser> userStatus;

        public UserManger(UserStatus<ApplicationUser> userStatus)
        {
            this.userStatus = userStatus;
        }

        internal object Find(string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        internal object CreateIdentity(object user, object applicationCookie)
        {
            throw new NotImplementedException();
        }
    }
}