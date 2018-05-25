using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using ngScaffolding.Controllers;
using ngScaffolding.database.Models;
using ngScaffolding.ExtensionMethods;
using ngScaffolding.Models;
using ngScaffolding.Models.DataSourceModels;
using ngScaffolding.Services;
using System.Threading.Tasks;

namespace ngScaffolding.Helpers
{
    public class SqlDataHelper
    {
        private readonly IConnectionStringsService _connectionStringsService;

        public class SqlDataResults
        {
            public List<Dictionary<string, object>> Results { get; set; }
            public ICollection<ActionResult> ActionResults { get; set; }
            public int RowCount { get; set; }

            public SqlDataResults()
            {
                ActionResults = new List<ActionResult>();
            }
        }

        public SqlDataHelper(IConnectionStringsService connectionStringsService)
        {
            _connectionStringsService = connectionStringsService;
        }
        public async Task<SqlDataResults> RunCommand(SqlDataSource command,
            ExpandoObject inputs = null,
            ICollection<ExpandoObject> rows = null,
            int pageNumber = 0,
            int pageSize = 0, string sort = null, string sortDirection = null)
        {

            var retVal = new SqlDataResults();

            //If no rows, create one so we run the process once
            if (rows == null)
            {
                rows = new List<ExpandoObject>();
            }

            if (!rows.Any())
            {
                rows.Add(new ExpandoObject());
            }

            foreach (var row in rows)
            {
                var paramList = new List<ParameterDetailModel>();

                //Setup SQL connection
                var connectionString = _connectionStringsService.Get(command.connection);

                //TODO: Commented out until EF Core supports EntityConnectionStringBuilder
                //if (connectionString.ToUpper().IndexOf("METADATA") > -1)
                //{
                //    connectionString = new EntityConnectionStringBuilder(connectionString).ProviderConnectionString;
                //}

                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();
                var commandString = command.sqlCommand;

                if (pageSize > 0)
                {
                    paramList.Add(new ParameterDetailModel()
                    {
                        name = "pageSize",
                        sqltype = "int",
                        value = string.Format("@pageSize = {0}", pageSize)
                    });

                    if (pageNumber == 0)
                    {
                        pageNumber = 1;
                    }
                }
                if (pageNumber > 0)
                {
                    paramList.Add(new ParameterDetailModel()
                    {
                        name = "pageNumber",
                        sqltype = "int",
                        value = string.Format("@pageNumber = {0}", pageNumber)
                    });
                }
                
                var extractedRowDetails = new List<KeyValuePair<string, string>>();

                //DBAINES - SWAPPED TWO BELOW - MIGHT NEED TO GO Back
                // 2. String Replacement from Inputs
                if (inputs != null)
                {
                    IDictionary<string, object> propertyValues = (IDictionary<string, object>)inputs;
                    foreach (var property in propertyValues)
                    {
                        var searchKey = string.Format("@@{0}", property.Key);
                        if (commandString.Contains(searchKey))
                        {
                            commandString = commandString.Replace(searchKey, property.Value.ToString());
                        }
                    }
                }

                // 1. String Replacement from Row
                if (row != null)
                {
                    foreach (var property in row)
                    {
                        if (property.Value != null)
                        {
                            extractedRowDetails.Add(new KeyValuePair<string, string>(property.Key,
                                property.Value.ToString()));
                        }
                        else
                        {
                            extractedRowDetails.Add(new KeyValuePair<string, string>(property.Key, string.Empty));
                        }

                        var searchKey = string.Format("@@{0}", property.Key);
                        if (commandString.Contains(searchKey))
                        {
                            if (property.Value == null)
                            {
                                commandString = commandString.Replace(searchKey, "NULL");
                            }
                            else
                            {
                                commandString = commandString.Replace(searchKey, property.Value.ToString());
                            }
                        }
                    }
                }

                

                // 3. Parameters from Row
                if (extractedRowDetails != null)
                {
                    foreach (var keyValuePair in extractedRowDetails)
                    {
                        if (command.parameters != null)
                        {
                            var thisParam =
                                command.parameters.FirstOrDefault(p => p.name.ToUpper() == keyValuePair.Key.ToUpper());

                            if (thisParam == null)
                            {
                                thisParam = new ParameterDetailModel();
                                thisParam.name = keyValuePair.Key;
                                thisParam.sqltype = "NVARCHAR(MAX)";
                                command.parameters.Add(thisParam);
                            }
                            thisParam.value = keyValuePair.Value;
                        }
                    }
                }

                // 4. Parameters from Inputs
                if (inputs != null)
                {
                    IDictionary<string, object> propertyValues = (IDictionary<string, object>)inputs;
                    foreach (var property in propertyValues)
                    {
                        if (command.parameters != null)
                        {
                            var thisParam =
                                command.parameters.FirstOrDefault(p => p.name.ToUpper() == property.Key.ToUpper());

                            if (thisParam == null)
                            {
                                thisParam = new ParameterDetailModel();
                                thisParam.name = property.Key;
                                command.parameters.Add(thisParam);
                            }

                            //if (string.IsNullOrEmpty(thisParam.Sqltype))
                            //{
                            //    thisParam.Sqltype = !string.IsNullOrEmpty(inputDetail.sqltype)
                            //        ? inputDetail.sqltype
                            //        : "NVARCHAR(MAX)";
                            //}
                            thisParam.value = property.Value;
                        }
                    }
                }

                
                //Add Parameters to end of call string from Parameter collection
                if (command.parameters != null)
                {
                    foreach (var param in command.parameters)
                    {
                        FormatParameter(param);
                    }
                }
                
                if (commandString.ToUpper().Contains("WHERE 1=1") && command.isPagedData)
                {
                    //#region "Dynamic SQL Here - Not needed for updates etc"

                    //foreach (var inputDetail in inputs)
                    //{
                    //    if (string.IsNullOrEmpty(inputDetail.defaultValue))// || alreadyProcessed.Contains(inputDetail.name))
                    //        continue;

                    //    switch (inputDetail.type.ToUpper())
                    //    {
                    //        //textbox, email, textarea, select, multiselect, date, datetime
                    //        case "TEXTBOX":
                    //        case "EMAIL":
                    //        case "TEXTAREA":
                    //        case "SELECT":
                    //            {
                    //                switch (inputDetail.comparison)
                    //                {
                    //                    case null:
                    //                    case "":
                    //                    case "=":
                    //                        {
                    //                            commandString = string.Format("{0} AND {1} = @{1}", commandString,
                    //                                inputDetail.name);
                    //                            break;
                    //                        }
                    //                    case "!=":
                    //                        {
                    //                            commandString = string.Format("{0} AND NOT {1} = @{1}", commandString,
                    //                                inputDetail.name);
                    //                            break;
                    //                        }
                    //                    case "starts":
                    //                        {
                    //                            commandString = string.Format("{0} AND {1} LIKE @{1}", commandString,
                    //                                inputDetail.name);
                    //                            break;
                    //                        }
                    //                    case "contains":
                    //                        {
                    //                            commandString = string.Format("{0} AND {1} LIKE @{1}", commandString,
                    //                                inputDetail.name);
                    //                            break;
                    //                        }
                    //                    case "lt":
                    //                        {
                    //                            commandString = string.Format("{0} AND {1} < @{1}", commandString,
                    //                                inputDetail.name);
                    //                            break;
                    //                        }
                    //                    case "gt":
                    //                        {
                    //                            commandString = string.Format("{0} AND {1} < @{1}", commandString,
                    //                                inputDetail.name);
                    //                            break;
                    //                        }
                    //                }
                    //                break;
                    //            }
                    //        case "MULTISELECT":
                    //            {
                    //                commandString = string.Format("{0} AND {1} IN ('{2}')", commandString, inputDetail.name,
                    //                    inputDetail.defaultValue);
                    //                break;
                    //            }
                    //        case "DATE":
                    //            {
                    //                break;
                    //            }
                    //        case "DATETIME":
                    //            {
                    //                break;
                    //            }
                    //    }

                    //    //alreadyProcessed.Add(inputDetail.name);
                    //}
                    //#endregion
                    //try
                    //{
                    //    //Now Add Paging Details

                    //    if (!command.IsStoredProc && command.IsPagedData)
                    //    {
                    //        commandString = commandString.ReplaceInsensitive("SELECT ",
                    //            "SELECT [RowCount] = COUNT(*) OVER(), ");

                    //        if (!string.IsNullOrEmpty(sort))
                    //        {
                    //            commandString = commandString + " ORDER BY [" + sort + "]";

                    //            if (!string.IsNullOrEmpty(sortDirection) && sortDirection.ToUpper() == "DESC")
                    //            {
                    //                commandString = commandString + " DESC ";
                    //            }
                    //        }

                    //        commandString = commandString +
                    //                        " OFFSET ((@pageNumber - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY ";
                    //    }

                    //    commandString = BookEndCommand(commandString, paramList);
                    //    var comm = new SqlCommand(commandString, conn) { CommandTimeout = 240 };

                    //    var reader = await comm.ExecuteReaderAsync();

                    //    retVal.Results = PopulateResults(reader);
                    //    retVal.RowCount = retVal.Results.Count;

                    //    //var adapter = new SqlDataAdapter(comm);
                    //    //retVal.Data = new DataTable();
                    //    //adapter.Fill(retVal.Data);

                    //    //retVal.ActionResults.Add(new ActionResult() { success = true });
                    //    //if (retVal.Data.Rows.Count > 0)
                    //    //{
                    //    //    //Now get RowCount and remove column
                    //    //    if (retVal.Data.Columns.Contains("RowCount"))
                    //    //    {
                    //    //        int rowCount;
                    //    //        int.TryParse(retVal.Data.Rows[0]["RowCount"].ToString(), out rowCount);
                    //    //        retVal.Data.Columns.Remove(retVal.Data.Columns["RowCount"]);
                    //    //        retVal.RowCount = rowCount;
                    //    //    }
                    //    //}
                    //    return retVal;
                    //}
                    //catch (Exception ex)
                    //{
                    //    retVal.ActionResults.Add(new ActionResult() { success = false, message = ex.Message });
                    //}
                }
                else
                {
                     try
                    {
                        commandString = BookEndCommand(commandString, command.parameters);

                        var comm = new SqlCommand(commandString, conn) { CommandTimeout = 240 };

                        var reader = await comm.ExecuteReaderAsync();

                        retVal.Results = PopulateResults(reader);
                        retVal.RowCount = retVal.Results.Count;

                        retVal.ActionResults.Add(new ActionResult() { success = true });

                        //if (retVal.Data.Rows.Count > 0)
                        //{
                        //    //Now get RowCount and remove column
                        //    if (retVal.Data.Columns.Contains("RowCount"))
                        //    {
                        //        int rowCount;
                        //        int.TryParse(retVal.Data.Rows[0]["RowCount"].ToString(),out rowCount);
                        //        retVal.Data.Columns.Remove(retVal.Data.Columns["RowCount"]);
                        //        retVal.RowCount = rowCount;
                        //    }
                        //}
                        //return retVal;
                    }
                    catch (Exception ex)
                    {
                        retVal.ActionResults.Add(new ActionResult() { success = false, message = ex.Message });
                    }
                }
            }
            return retVal;
        }

        private static List<Dictionary<string, object>> PopulateResults(SqlDataReader reader)
        {
            var retVal = new List<Dictionary<string, object>>();

            // Get our column Names for output
            var columns = Enumerable.Range(0, reader.FieldCount)
                .Select(reader.GetName)
                .ToList();

            // Rows go here

            while (reader.Read())
            {
                retVal.Add(columns.ToDictionary(column => column, column => reader[column]));
            }

            return retVal;
        }

        private static ParameterDetailModel FormatParameter(ParameterDetailModel param)
        {
            if (param.sqltype.ToUpper().Contains("CHAR"))
            {
                param.value = string.Format("@{0} = N'{1}'", param.name, param.value != null ? param.value.ToString().Trim() : null);
            }
            else if (param.sqltype.ToUpper().Contains("DATE"))
            {
                param.value = string.Format("@{0} = N'{1}'", param.name, param.value != null ? param.value.ToString().Trim() : null);
            }
            else if (param.sqltype.ToUpper() == "BIT")
            {
                var test = param.value.ToString().ToUpper().Trim();
                if (string.IsNullOrEmpty(test))  //NULL
                {
                    param.value = string.Format("@{0} = NULL", param.name);
                }
                else if (test == "Y" || test == "1" || test == "TRUE" || test == "YES") //Truthy
                {
                    param.value = string.Format("@{0} = 1", param.name);
                }
                else //FALSE
                {
                    param.value = string.Format("@{0} = 0", param.name);
                }
            }
            else
            {
                param.value = string.Format("@{0} = {1}", param.name, param.value != null ? param.value.ToString().Trim() : "NULL");
            }

            return param;
        }

        private static string BookEndCommand(string commandString, IEnumerable<ParameterDetailModel> paramList)
        {
            commandString = "exec sp_executesql N'" + commandString;
            commandString = commandString + "'";

            if (paramList != null && paramList.Any())
            {
                commandString = string.Format("{0} , N'{1}' ", commandString,
                    string.Join(",", paramList.Select(p => string.Format("@{0} {1}", p.name, p.sqltype))));

                commandString = string.Format("{0} , {1} ", commandString,
                    string.Join(",", paramList.Select(p => p.value)));
            }

            return commandString;
        }

    }
}