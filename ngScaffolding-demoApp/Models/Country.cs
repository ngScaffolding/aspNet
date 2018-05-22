using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ngScaffolding.demoApp.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ContinentId { get; set; }
        [ForeignKey("ContinentId")]
        public virtual Continent Continent { get; set; }
    }
}
