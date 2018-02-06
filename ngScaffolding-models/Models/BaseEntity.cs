using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngScaffolding.models.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }

    public class BaseRoleEntity : BaseEntity
    {
        [StringLength(500)]
        public string Roles { get; set; }

        public bool IsUserInRoles()
        {
            return true;
        }
    }
}
