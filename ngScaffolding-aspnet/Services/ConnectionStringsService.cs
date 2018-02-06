using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngScaffolding.Services
{
    public class ConnectionStringsService : IConnectionStringsService
    {
        private Dictionary<string,string> _connectionStrings = new Dictionary<string, string>();

        public void Add(string Name, string Value)
        {
            _connectionStrings[Name] = Value;
        }

        public string Get(string Name)
        {
            if (_connectionStrings.ContainsKey(Name))
            {
                return _connectionStrings[Name];
            }
            else
            {
                return null;
            }
        }
    }
}
