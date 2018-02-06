using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ngScaffolding.database;
using ngScaffolding.Data;
using ngScaffolding.ExtensionMethods;
using ngScaffolding.models.Models;
using ngScaffolding.Services;

namespace ngScaffolding.Controllers
{
    [Produces("application/json")]
    [Route("api/UserPreferences")]
    public class UserPreferencesController: ngScaffoldingController
    {
        private readonly IRepository<UserPreference> _userPreferenceRepository;

        public UserPreferencesController(IRepository<UserPreference> userPreferenceRepository)
        {
            _userPreferenceRepository = userPreferenceRepository;
        }

        // GET: api/ReferenceValues
        [HttpGet]
        public IEnumerable<UserPreference> Get()
        {
            return _userPreferenceRepository.GetAll();
        }
    }
}
