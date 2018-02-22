using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngScaffolding.models.Models
{
    public class UserPreferenceValue : BaseEntity
    {
        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(2000)]

        public string Value { get; set; }

        public virtual UserPreferenceDefinition UserPreferenceDefinition { get; set; }
    }
}
