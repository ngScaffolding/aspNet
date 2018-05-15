using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models.DataSourceModels
{
    public class BaseDataSource
    {
        public string Title { get; set; }

        public string Connection { get; set; }
        public string SqlCommand { get; set; }

        public bool IsStoredProcedure { get; set; }

        public bool IsPagedData { get; set; }
        public bool IsAudit { get; set; }

        // Name Of DataSource to flush on completed
        public string FlushDataSource { get; set; }

        public ICollection<ParameterDetailModel> Parameters { get; set; }

    }
}
