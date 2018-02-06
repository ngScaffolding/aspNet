using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ngScaffolding.database.Models;
using ngScaffolding.Services;

namespace ngScaffolding.Helpers
{
    public class ReferenceValuesHelper
    {
        private readonly IConnectionStringsService _connectionStringsService;

        public ReferenceValuesHelper(IConnectionStringsService connectionStringsService)
        {
            _connectionStringsService = connectionStringsService;
        }

        public void PopulateOptionList(IReferenceValuesService referenceValuesService, ReferenceValue referenceValue, string seed = null)
        {
            switch (referenceValue.Type)
            {
                case ReferenceValue.Types_SingleValue:
                    {
                        break;
                    }
                case ReferenceValue.Types_List:
                    {
                        foreach (var referenceValueItem in referenceValuesService.GetValue(referenceValue.Name).ReferenceValueItems.OrderBy(o => o.ItemOrder))
                        {
                            if (string.IsNullOrEmpty(referenceValueItem.Display) && !string.IsNullOrEmpty(referenceValueItem.Value))
                            {
                                referenceValueItem.Display = referenceValueItem.Value;
                            }
                            referenceValue.ReferenceValueItems.Add(referenceValueItem);
                        }

                        break;
                    }
                case ReferenceValue.Types_DatabaseQuery:
                    {
                        //Setup SQL connection
                        var connectionString = _connectionStringsService.Get(referenceValue.ConnectionName);
                        SqlConnection conn = new SqlConnection(connectionString);

                        conn.Open();
                        var command = referenceValue.Value;

                        if (!string.IsNullOrEmpty(seed))
                        {
                            command = command.Replace("@@Seed", seed);
                        }
                        else
                        {
                            command = command.Replace("@@Seed", "NULL");
                        }

                        var comm = new SqlCommand(command, conn) { CommandTimeout = 30 };

                        var result = comm.ExecuteReader(CommandBehavior.CloseConnection);

                        int order = 0;
                        while (result.Read())
                        {
                            var opt = new ReferenceValueItem()
                            {
                                ItemOrder = order++,
                            };

                            if (HasColumn(result, "Display"))
                            {
                                opt.Display = result["Display"].ToString();
                            }

                            if (HasColumn(result, "Value"))
                            {
                                opt.Value = result["Value"].ToString();
                            }

                            if (HasColumn(result, "SubTitle"))
                            {
                                opt.SubTitle= result["SubTitle"].ToString();
                            }

                            if (HasColumn(result, "SubTitle2"))
                            {
                                opt.SubTitle2 = result["SubTitle2"].ToString();
                            }
                            
                            referenceValue.ReferenceValueItems.Add(opt);
                        }

                        break;
                    }
            }
        }

        public static bool HasColumn(SqlDataReader Reader, string ColumnName)
        {
            foreach (DataRow row in Reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString() == ColumnName)
                    return true;
            } //Still here? Column not found. 
            return false;
        }
    }
}