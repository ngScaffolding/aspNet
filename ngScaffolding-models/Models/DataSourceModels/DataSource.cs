using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ngScaffolding.models.Models;
using ngScaffolding.Models.DataSourceModels;
using Newtonsoft.Json;

namespace ngScaffolding.Models
{
    
    public class DataSource: BaseEntity
    {
        private BaseDataSource _dataSourceDetails;

        public const string TypesSql = "SQL";
        public const string TypesRestApi = "RestAPI";

        [StringLength(200)]
        public string Type { get; set; }

        public string JsonContent { get; set; }

        [NotMapped]
        public BaseDataSource DataSourceDetails
        {
            get { return _dataSourceDetails; }
            set
            {
                _dataSourceDetails = value;
                // Serialize to our string value here.
                JsonContent = JsonConvert.SerializeObject(value);
            }
        }
    }
}
