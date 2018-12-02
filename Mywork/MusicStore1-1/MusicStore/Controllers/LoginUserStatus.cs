using MusicStoreEntity;

namespace MusicStore.Controllers
{
    internal class UserStatus<T>
    {
        private EntityDbContext entityDbContext;

        public UserStatus(EntityDbContext entityDbContext)
        {
            this.entityDbContext = entityDbContext;
        }
    }
}