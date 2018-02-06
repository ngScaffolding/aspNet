using System;
using System.Collections.Generic;
using System.Text;

namespace ngScaffolding.Models.DataSourceModels
{
    public class RestApiDataSource : BaseDataSource
    {
        public string  EndPointName { get; set; }
        public string EndPointVerb { get; set; }
    }
}
