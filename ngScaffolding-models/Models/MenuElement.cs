using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ngScaffolding.models.Models;

namespace ngScaffolding.database.Models
{
    public class MenuElement:BaseRoleEntity
    {
        // Following are copied from PrimeNG MenuItem

        [StringLength(200)]
        public string label { get; set; }
        [StringLength(200)]
        public string icon { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(200)]
        public string command { get; set; }
        [StringLength(200)]
        public string Url { get; set; }
        [StringLength(500)]
        public string routerLink { get; set; }

        [StringLength(200)]
        public string target { get; set; }
        [StringLength(500)]
        public string routerLinkActiveOptions { get; set; }
        public bool separator { get; set; }
        [StringLength(200)]
        public string badge { get; set; }
        [StringLength(200)]
        public string badgeStyleClass { get; set; }
        [StringLength(200)]
        public string style { get; set; }
        [StringLength(200)]
        public string styleClass { get; set; }

    }
}