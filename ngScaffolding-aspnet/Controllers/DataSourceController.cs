using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ngScaffolding.database;
using ngScaffolding.Data;
using ngScaffolding.Helpers;
using ngScaffolding.Infrastructure;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;
using ngScaffolding.Services;
using Newtonsoft.Json;

namespace ngScaffolding.Controllers
{
    [Route("api/DataSource")]
    public class DataSourceController : ngScaffoldingController
    {
        private readonly IConnectionStringsService _connectionStringsService;
        private readonly IRepository<DataSource> _dataSourceRepository;

        public class DataSourceRequest
        {
            public string Name { get; set; }
            public string MenuId { get; set; }
            public string Seed { get; set; }
            public string RowData { get; set; }
            public string InputData { get; set; }
            public int? PageNumber { get; set; }
            public int? PageSize { get; set; }
        }

        public class DataResults
        {
            public int rowCount { get; set; }
            public string jsonData { get; set; }
        }

        public DataSourceController(IConnectionStringsService connectionStringsService,
            IRepository<DataSource> dataSourceRepository)
        {
            _connectionStringsService = connectionStringsService;
            _dataSourceRepository = dataSourceRepository;
        }

        // POST: api/GridData
        [HttpPost]
        //[ServiceFilter(typeof(AuditAttribute))]
        public async Task<IActionResult> Post([FromBody] DataSourceRequest dataSourceRequest)
        {
            if (dataSourceRequest != null)
            {
                DataSource dataSource = null;

                if (!string.IsNullOrEmpty(dataSourceRequest.MenuId))
                {

                }
                else
                {
                    _dataSourceRepository.GetAll().FirstOrDefault(n => n.Name.ToUpper() == dataSourceRequest.Name.ToUpper());
                }

                if (dataSource != null)
                {
                    var sqlHelper = new SqlDataHelper(_connectionStringsService);
                    var sqlDatasource = JsonConvert.DeserializeObject<SqlDataSource>(dataSource.JsonContent);
                    if (sqlDatasource != null)
                    {
                        var results = await sqlHelper.RunCommand(sqlDatasource);

                        //var retVal = new DataResults()
                        //{
                        //    rowCount = results.RowCount,
                        //    jsonData = JsonConvert.SerializeObject(results.Data, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include })
                        //};
                        return Ok(results);
                    }
                }
            }
            return NotFound();
        }
    }
}
