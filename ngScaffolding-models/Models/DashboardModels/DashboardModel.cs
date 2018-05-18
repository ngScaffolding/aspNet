using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models
{
    public class DashboardModel
    {
        public string title { get; set; }
        public bool? isReadOnly { get; set; }
        public IEnumerable<WidgetModel> widgets { get; set; }

        public IEnumerable<string> userIds { get; set; }
        public IEnumerable<string> groups { get; set; }
    }
}
