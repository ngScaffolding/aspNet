using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.demoApp.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Country> Countries { get; set; }
    }
}
