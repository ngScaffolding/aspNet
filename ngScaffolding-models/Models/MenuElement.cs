using System.ComponentModel.DataAnnotations;
using ngScaffolding.models.Models;

namespace ngScaffolding.database.Models
{
    public class MenuElement:BaseRoleEntity
    {
        // Following are copied from PrimeNG MenuItem

        [StringLength(200)]
        public string Label { get; set; }
        [StringLength(200)]
        public string Icon { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(200)]
        public string Command { get; set; }
        [StringLength(200)]
        public string Url { get; set; }
        [StringLength(500)]
        public string RouterLink { get; set; }

        [StringLength(200)]
        public string Target { get; set; }
        [StringLength(500)]
        public string RouterLinkActiveOptions { get; set; }
        public bool Separator { get; set; }
        [StringLength(200)]
        public string Badge { get; set; }
        [StringLength(200)]
        public string BadgeStyleClass { get; set; }
        [StringLength(200)]
        public string Style { get; set; }
        [StringLength(200)]
        public string StyleClass { get; set; }
    }
}