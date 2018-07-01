using System;
using System.Collections.Generic;
using System.Text;
using ngScaffolding.database.Models;

namespace ngScaffolding.Models.DataSourceModels
{
    public class SqlDataSource : BaseDataSource
    {
        public string testCommand { get; set; }

        public string connection { get; set; }
        public string sqlCommand { get; set; }

        public bool isStoredProcedure { get; set; }

        public SqlDataSource()
        {
            base.type = BaseDataSource.TypesSql;
        }
    }
}
