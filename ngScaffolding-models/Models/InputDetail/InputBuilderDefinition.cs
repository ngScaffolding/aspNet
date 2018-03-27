using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.database.Models
{
    public class InputBuilderDefinition
    {
        public string orientation { get; set; }
        public int horizontalColumnCount { get; set; }

        public string okButtonText { get; set; }
        public string okButtonIcon { get; set; }

        public string cancelButtonText { get; set; }
        public string cancelButtonIcon { get; set; }

        public IEnumerable<InputDetail> inputDetails { get; set; }

        public string customButtonText { get; set; }
        public string customButtonIcon { get; set; }

    }
}
