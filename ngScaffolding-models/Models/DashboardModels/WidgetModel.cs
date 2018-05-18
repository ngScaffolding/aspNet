using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models
{
    public class WidgetModel
    {
        public string title { get; set; }

        public string configuredValues { get; set; }
        public int? col { get; set; }
        public int? row { get; set; }
        public int? sizeX { get; set; }
        public int? sizeY { get; set; }
        public string style { get; set; }
        public int? refreshInterval { get; set; }

        public GridViewDetailModel gridViewDetail { get; set; }
        public ChartDetailModel chartDetail { get; set; }
        public HTMLContentModel htmlContent { get; set; }
    }
}
