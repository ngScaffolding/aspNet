using System;
using System.Collections.Generic;
using System.Text;
using ngScaffolding.database.Models;

namespace ngScaffolding.Models.DataSourceModels
{
    public class SqlDataSource: BaseDataSource
    {
        public string Connection { get; set; }
        public string SqlCommand { get; set; }
        public string TestCommand { get; set; }

        // do we need this?
        public bool IsStoredProc { get; set; }

        public ICollection<ParameterDetailModel> Parameters { get; set; }

        public ICollection<InputDetail> InputControls { get; set; }
    }
}
