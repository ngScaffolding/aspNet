using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models.DataSourceModels
{
    public class BaseDataSource
    {
        public bool IsPagedData { get; set; }
        public bool IsAudit { get; set; }

        // Name Of DataSource to flush on completed
        public string FlushDataSource { get; set; }
    }
}
