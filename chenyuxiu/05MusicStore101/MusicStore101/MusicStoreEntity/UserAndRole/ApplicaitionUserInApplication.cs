using System;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreEntities.UserAndRole
{
    public class ApplicaitionUserInApplication
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SortCode { get; set; }

        public virtual ApplicationInformation AppInfo { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ApplicaitionUserInApplication()
        {
            this.ID = Guid.NewGuid();
        }
    }
}