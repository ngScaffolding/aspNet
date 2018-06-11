using ngScaffolding.database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models
{
    public class ChartDetailModel
    {
        public string title { get; set; }
        public InputBuilderDefinition filters { get; set; }

        public bool? firstColumnXAxis { get; set; }
        public string[] seriesNames { get; set; }
        public string chartOptions { get; set; }

        public int? dataSourceId { get; set; }
    }
}
