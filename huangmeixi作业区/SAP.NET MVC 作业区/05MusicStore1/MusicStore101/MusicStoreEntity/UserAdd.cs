using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreEntity
{
    public class UserAdd
    {
        public Guid ID { get; set; }
        public virtual Person Person { get; set; }
        public string OrderAdd { get; set; }
        public UserAdd()
        {
            ID = Guid.NewGuid();
        }
    }
}