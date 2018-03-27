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
using ngScaffolding.database.Models;
using System.Dynamic;
using Newtonsoft.Json.Converters;

namespace ngScaffolding.Controllers
{
    [Route("api/DataSource")]
    public class DataSourceController : ngScaffoldingController
    {
        private readonly IConnectionStringsService _connectionStringsService;
        private readonly IRepository<DataSource> _dataSourceRepository;

        public IRepository<MenuItem> _menuItemRepository { get; }

        public class DataSourceRequest
        {
            public int Id { get; set; }
            public string Seed { get; set; }
            public string FilterValues { get; set; }
            public string RowData { get; set; }
            public string InputData { get; set; }
            public int? PageNumber { get; set; }
            public int? PageSize { get; set; }
        }

        public class DataResults
        {
            public int rowCount { get; set; }
            public string jsonData { get; set; }
            public ICollection<ActionResult> results { get; set; }
        }

        public DataSourceController(IConnectionStringsService connectionStringsService,
            IRepository<MenuItem> menuItemRepository,
            IRepository<DataSource> dataSourceRepository)
        {
            _connectionStringsService = connectionStringsService;
            _menuItemRepository = menuItemRepository;
            _dataSourceRepository = dataSourceRepository;
        }

        // POST: api/DataSource
        [HttpPost]
        //[ServiceFilter(typeof(AuditAttribute))]
        public async Task<IActionResult> Post([FromBody] DataSourceRequest dataSourceRequest)
        {
            if (dataSourceRequest != null)
            {
                var dataSource = _dataSourceRepository.Get(dataSourceRequest.Id);

                if (dataSource != null)
                {
                    dynamic filterValues = null;

                    // Work out Filter Values
                    if (!string.IsNullOrEmpty(dataSourceRequest.FilterValues))
                    {
                        var converter = new ExpandoObjectConverter();
                        filterValues = JsonConvert.DeserializeObject<ExpandoObject>(dataSourceRequest.FilterValues, converter);
                    }

                    var sqlHelper = new SqlDataHelper(_connectionStringsService);
                    var sqlDatasource = JsonConvert.DeserializeObject<SqlDataSource>(dataSource.JsonContent);
                    if (sqlDatasource != null)
                    {
                        var sqlResults = await sqlHelper.RunCommand(sqlDatasource, filterValues);

                        var retVal = new DataResults()
                        {
                            rowCount = sqlResults.RowCount,
                            jsonData = JsonConvert.SerializeObject(sqlResults.Results, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include }),
                            results = sqlResults.ActionResults
                        };

                        return Ok(retVal);
                    }
                }
            }
            return NotFound();
        }
    }
}
