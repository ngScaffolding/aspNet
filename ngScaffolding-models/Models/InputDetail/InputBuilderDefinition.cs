using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.database.Models
{
    public class InputBuilderDefinition
    {
        public string Orientation { get; set; }
        public int HorizontalColumnCount { get; set; }

        public string OkButtonText { get; set; }
        public string OkButtonIcon { get; set; }

        public string CancelButtonText { get; set; }
        public string CancelButtonIcon { get; set; }

        public IEnumerable<InputDetail> InputDetails { get; set; }

        public string CustomButtonText { get; set; }
        public string CustomButtonIcon { get; set; }

    }
}
