using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreEntities.UserAndRole
{
    public class ApplicationRole : IdentityRole
    {
        [StringLength(250)]
        public string DisplayName { get; set; }

        [StringLength(550)]
        public string Description { get; set; }

        [StringLength(50)]
        public string SortCode { get; set; }

        public ApplicationRoleType ApplicationRoleType { get; set; }
    }
}