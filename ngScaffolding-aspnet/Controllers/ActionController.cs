﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ngScaffolding.Data;
using ngScaffolding.Helpers;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;
using ngScaffolding.Services;

namespace ngScaffolding_aspnet.Controllers
{
    public class ActionRequest
    {

        public ActionModel action { get; set; }
        public string inputDetails { get; set; }
        public string rows { get; set; }
    }

    public class ActionResult
    {
        public bool success { get; set; }
        public string message { get; set; } 
    }


    [Produces("application/json")]
    [Route("api/v1/action")]
    public class ActionController : Controller
    {
        private readonly IRepository<DataSource> _dataSourceRepository;
        private readonly IConnectionStringsService _connectionStringsService;

        public ActionController(IRepository<DataSource> dataSourceRepository, IConnectionStringsService connectionStringsService)
        {
            this._dataSourceRepository = dataSourceRepository;
            this._connectionStringsService = connectionStringsService;
        }

        // GET: api/Action
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Action/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Action
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ActionRequest actionRequest)
        {
            //Decode input Model
            dynamic inputs = JsonConvert.DeserializeObject<ExpandoObject>(actionRequest.inputDetails);

            List<ExpandoObject> rowsObjects = new List<ExpandoObject>();
            if (!string.IsNullOrEmpty(actionRequest.rows))
            {
                if (actionRequest.rows.StartsWith("[") && actionRequest.rows.EndsWith("]"))
                {
                    rowsObjects = JsonConvert.DeserializeObject<List<ExpandoObject>>(actionRequest.rows);
                }
                else
                {
                    dynamic row = JsonConvert.DeserializeObject<ExpandoObject>(actionRequest.rows);
                    rowsObjects.Add(row);
                }
            }

            switch (actionRequest.action.type.ToUpper())
            {
                case "SQLCOMMAND":
                    {
                        // Get datasource which hold the SQL we want to run
                        if (string.IsNullOrEmpty(actionRequest.action.dataSourceName))
                        {
                            return BadRequest("No dataSource Name provided");
                        }
                        var dataSource = _dataSourceRepository.GetByName(actionRequest.action.dataSourceName);
                        var sqlCommand = JsonConvert.DeserializeObject<SqlDataSource>(dataSource.JsonContent);

                        var sqlHelper = new SqlDataHelper(_connectionStringsService);
                        var results = await sqlHelper.RunCommand(sqlCommand, inputs, rowsObjects);
                        break;
                    }
                case "Url":
                    {
                        break;
                    }
                case "AngularController":
                    {
                        break;
                    }
            }
            return Ok(new ActionResult() { success = true, message = "Yay, Done" });
        }

        // PUT: api/Action/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
