using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ngScaffolding.database;
using ngScaffolding.database.Models;
using ngScaffolding.Data;

namespace ngScaffolding.Services
{
    public interface IReferenceValuesService
    {
        ReferenceValue GetDefinition(string name);
        ReferenceValue GetValue(string name, string seed = null);
        IEnumerable<ReferenceValue> GetGroup(string group);
    }

    public class ReferenceValuesService : IReferenceValuesService
    {
        private readonly ngScaffoldingContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;
        private readonly IRepository<ReferenceValue> _referenceValues;

        public ReferenceValuesService(ngScaffoldingContext context,
            IConfiguration configuration,
            ICacheService cacheService,
            IRepository<ReferenceValue> referenceValues)
        {
            _context = context;
            _configuration = configuration;
            _cacheService = cacheService;
            _referenceValues = referenceValues;
        }

        public IEnumerable<ReferenceValue> GetGroup(string group)
        {
            var groupResults = _referenceValues.GetAll().Where(r => !string.IsNullOrEmpty(r.GroupName) && r.GroupName.ToLower() == group.ToLower());
            foreach (var referenceValue in groupResults)
            {
                PopulateOptionList(referenceValue);
                referenceValue.CleanForClient();
            }

            return groupResults;
        }

        public IEnumerable<ReferenceValueItem> Get()
        {
            return _referenceValues.Get(1).ReferenceValueItems;
        }

        public ReferenceValue GetDefinition(string name)
        {
            ReferenceValue retVal = null;
            retVal = _referenceValues.GetAll().FirstOrDefault(r => r.name.ToLower() == name.ToLower());

            return retVal;
        }

        public ReferenceValue GetValue(string name, string seed = null)
        {
            var key = GetKey(name, seed);
            //var retVal = _cacheService.Get(key) as ReferenceValue;

            ReferenceValue retVal = null;

            if (retVal == null)
            {
                retVal = this.GetDefinition(name);

                if (retVal != null)
                {
                    if (retVal.Type == ReferenceValue.Types_DatabaseQuery ||
                        retVal.Type == ReferenceValue.Types_RestAPI ||
                        retVal.Type == ReferenceValue.Types_List)
                    {
                        //Populate Values for non Value Types
                        PopulateOptionList(retVal, seed);

                    }

                    _cacheService.Set(key, retVal, retVal.CacheSeconds);
                }
            }

            return retVal;
        }

        private string GetKey(string name, string group = null)
        {
            return string.Format("ReferenceValues::{0}::{1}", name, group);
        }

        private void PopulateOptionList(ReferenceValue refValue, string seed = null)
        {
            switch (refValue.Type)
            {
                case ReferenceValue.Types_SingleValue:
                    {
                        break;
                    }
                case ReferenceValue.Types_List:
                    {
                        IEnumerable<ReferenceValueItem> referenceValues = null;

                        if (string.IsNullOrEmpty(seed))
                        {
                            referenceValues = _context.ReferenceValueItems.Where(r => r.ReferenceValueId == refValue.id);
                        }
                        else
                        {
                            referenceValues = _context.ReferenceValueItems.Where(r => r.ReferenceValueId == refValue.id)
                                .Where(r => r.Display.Contains(seed) || r.Value.Contains(seed) || r.SubTitle.Contains(seed) || r.SubTitle2.Contains(seed));
                        }

                        var refsToAdd = new List<ReferenceValueItem>();

                        foreach (var refItem in referenceValues.OrderBy(o => o.ItemOrder).ThenBy(o => o.Display))
                        {
                            if (string.IsNullOrEmpty(refItem.Display) && !string.IsNullOrEmpty(refItem.Value))
                            {
                                refItem.Display = refItem.Value;
                            }
                            refsToAdd.Add(refItem);
                        }

                        refValue.ReferenceValueItems.Clear();

                        foreach (var newItem in refsToAdd)
                        {
                            refValue.ReferenceValueItems.Add(newItem);
                        }

                        break;
                    }
                case ReferenceValue.Types_DatabaseQuery:
                    {
                        //Setup SQL connection
                        var connectionString = _configuration.GetConnectionString(refValue.ConnectionName);
                        SqlConnection conn = new SqlConnection(connectionString);

                        conn.Open();
                        var command = refValue.Value;

                        if (!string.IsNullOrEmpty(seed))
                        {
                            command = command.Replace("@@Seed", seed,StringComparison.InvariantCultureIgnoreCase);
                        }
                        else
                        {
                            command = command.Replace("@@Seed", "NULL", StringComparison.InvariantCultureIgnoreCase);
                        }

                        // Clear DB Script from Results
                        refValue.Value = null;

                        // Replace double quotes as we have no SQL Exec wrapper here
                        command = command.Replace("''", "'");

                        var comm = new SqlCommand(command, conn) { CommandTimeout = 30 };
                        
                        var reader = comm.ExecuteReader(CommandBehavior.CloseConnection);

                        int order = 0;

                        // Get our column Names for output
                        var columns = Enumerable.Range(0, reader.FieldCount)
                            .Select(reader.GetName)
                            .ToList();

                        while (reader.Read())
                        {
                            var opt = new ReferenceValueItem()
                            {
                                ItemOrder = order++,
                            };

                            if (columns.Contains("Display",StringComparer.InvariantCultureIgnoreCase))
                            {
                                opt.Display = reader["Display"].ToString();
                            }

                            if (columns.Contains("Value", StringComparer.InvariantCultureIgnoreCase))
                            {
                                opt.Value = reader["Value"].ToString();
                            }

                            refValue.ReferenceValueItems.Add(opt);
                        }

                        break;
                    }
            }
        }
    }
}
