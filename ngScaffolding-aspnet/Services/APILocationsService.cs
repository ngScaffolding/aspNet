using ngScaffolding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ngScaffolding.Services
{
    public interface IAPILocationsService
    {
        void Add(string name, APILocation location);
        APILocation Get(string name);
    }

    public class APILocationsService: IAPILocationsService
    {
        private Dictionary<string, APILocation> _apiLocations = new Dictionary<string, APILocation>();


        public void Add(string name, APILocation location)
        {
            _apiLocations[name] = location;
        }


        public APILocation Get(string name)
        {
            if (_apiLocations.ContainsKey(name))
            {
                return _apiLocations[name];
            }
            else
            {
                return null;
            }
        }
    }
}
