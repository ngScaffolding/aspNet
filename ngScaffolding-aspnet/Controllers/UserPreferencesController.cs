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
    public class UserPreferenceDefinitionsController: ngScaffoldingController
    {
        private readonly IRepository<UserPreferenceDefinition> _userPreferenceRepository;

        public UserPreferenceDefinitionsController(IRepository<UserPreferenceDefinition> userPreferenceRepository)
        {
            _userPreferenceRepository = userPreferenceRepository;
        }

        // GET: api/ReferenceValues
        [HttpGet]
        public IEnumerable<UserPreferenceDefinition> Get()
        {
            return _userPreferenceRepository.GetAll();
        }
    }
}
