using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.ViewModels
{
    public class ReplyViewModel
    {
        public Guid ID { get; set; }

        public List<Reply> Content { get; set; }

        public virtual Person Person { get; set; }

        public virtual Album Album { get; set; }

        public DateTime ReplyTime { get; set; }
    }
}