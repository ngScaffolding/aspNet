using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ngScaffolding.database;
using ngScaffolding.Data;
using ngScaffolding.ExtensionMethods;
using ngScaffolding.models.Models;
using ngScaffolding.Services;
using ngScaffolding.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ngScaffolding.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/UserPreferenceDefinitions")]
    public class UserPreferenceDefinitionsController : ngScaffoldingController
    {
        private readonly IRepository<UserPreferenceDefinition> _userPreferenceRepository;
        private readonly IUserService _userService;

        public UserPreferenceDefinitionsController(IRepository<UserPreferenceDefinition> userPreferenceRepository, IUserService userService)
        {
            _userPreferenceRepository = userPreferenceRepository;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(AuditAttribute))]
        public async Task<IEnumerable<UserPreferenceDefinition>> Get()
        {
            var user = await _userService.GetUser();

            return _userPreferenceRepository.GetAll().Where(d => user.IsInRoles(d.roles));
        }
    }
}
