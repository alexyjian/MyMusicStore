using MusicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{
    internal class LoginUserSessionModel
    {
        public LoginUserSessionModel()
        {
        }

        public Person Person { get; set; }
        public string RoleName { get; set; }
        public ApplicationUser User { get; set; }
    }
}