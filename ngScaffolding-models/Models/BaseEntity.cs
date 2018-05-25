using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngScaffolding.models.Models
{
    public class BaseEntity
    {
        [Column("Id", Order = 0)]
        public int id { get; set; }

        [StringLength(200)]
        [Column("Name", Order = 1)]
        public string name { get; set; }
    }

    public class BaseRoleEntity : BaseEntity
    {
        [Column("Roles", Order = 2)]
        [StringLength(500)]
        public string roles { get; set; }

        public bool IsUserInRoles()
        {
            return true;
        }
    }
}
