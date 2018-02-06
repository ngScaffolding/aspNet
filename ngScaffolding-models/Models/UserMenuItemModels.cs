using System.ComponentModel.DataAnnotations;
using ngScaffolding.models.Models;

namespace ngScaffolding.database.Models
{
    public class UserMenuItem:BaseEntity
    {
        public string UserID { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }


    public class GroupMenuItem: BaseEntity
    {
        public string UserID { get; set; }

        public virtual MenuItem MenuItem { get; set; }  
    }
}