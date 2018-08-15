using ngScaffolding.database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models.DataSourceModels
{
    public class BaseDataSource
    {
        public const string TypesSql = "SQL";
        public const string TypesRestApi = "RestAPI";
        public const string TypesMongoDB = "MongoDB";
        public const string TypesMySQL = "MySQL";

        public string type { get; set; }
        public string name { get; set; }

        public bool isPagedData { get; set; }
        public bool isAudit { get; set; }

        // Name Of DataSource to flush on completed
        public string flushReferenceValues { get; set; }

        public ICollection<ParameterDetailModel> parameters { get; set; }

        public ICollection<InputDetail> inputControls { get; set; }
    }
}
