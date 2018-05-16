using ngScaffolding.database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models
{
    public class ChartDetailModel
    {
        public String title { get; set; }
        public InputBuilderDefinition filters { get; set; }

        public Highsoft.Web.Mvc.Charts.Chart chartOptions { get; set; }

        public int dataSourceId { get; set; }
    }
}
