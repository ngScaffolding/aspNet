using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ngScaffolding.database;
using ngScaffolding.Data;
using ngScaffolding.Models;

namespace ngScaffolding.Services
{
    public interface IDataSourceService
    {
        DataSource GetDataSource(string name);
        DataSource GetDataSource(int id);
    }
    public class DataSourceService: IDataSourceService
    {
        private readonly IRepository<DataSource> _dataSources;

        public DataSourceService(IRepository<DataSource> dataSources)
        {
            _dataSources = dataSources;
        }

        public DataSource GetDataSource(string name)
        {
            return _dataSources.GetAll().FirstOrDefault(d => d.name.ToUpper() == name.ToUpper());
        }

        public DataSource GetDataSource(int id)
        {
            return _dataSources.Get(id);
        }
    }
}
