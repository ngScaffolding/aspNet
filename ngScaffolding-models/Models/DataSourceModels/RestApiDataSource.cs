using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models.DataSourceModels
{
    public class RestApiDataSource : BaseDataSource
    {
        public const string Response_JSON = "json";

        public string serverName { get; set; }
        public string url { get; set; }
        public string verb { get; set; }
        public string responseType { get; set; }

        public IEnumerable<string> headerValues { get; set; }

        public RestApiDataSource()
        {
            base.type = BaseDataSource.TypesRestApi;
        }
    }
}
