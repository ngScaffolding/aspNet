using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngScaffolding.models.Models
{
    public class UserPreferenceDefinition :BaseEntity
    {
        [StringLength(2000)]
        public string Value { get; set; }

        public string InputDetails { get; set; }

        public bool? Enabled { get; set; }
    }
}