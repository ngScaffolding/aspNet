using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models.DataSourceModels
{
    public class RestApiDataSource : BaseDataSource
    {
        public string serverName { get; set; }
        public string url { get; set; }
        public string verb { get; set; }

        public IEnumerable<string> headerValues { get; set; }

        public RestApiDataSource()
        {
            base.type = BaseDataSource.TypesRestApi;
        }
    }
}
