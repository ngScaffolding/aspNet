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
    [Route("api/UserPreferenceValues")]
    public class UserPreferenceValuesController: ngScaffoldingController
    {
        private readonly IRepository<UserPreferenceValue> _userPreferenceRepository;
        private readonly IUserService _userService;

        public UserPreferenceValuesController(IRepository<UserPreferenceValue> userPreferenceRepository, IUserService userService)
        {
            _userPreferenceRepository = userPreferenceRepository;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(AuditAttribute))]
        public async Task<IEnumerable<UserPreferenceValue>> Get()
        {
            var user = await _userService.GetUser();

            return _userPreferenceRepository
                .GetAll()
                .Where(d => d.UserId.ToLower() == user.Id.ToLower());
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(AuditAttribute))]
        public async Task<IActionResult> Post([FromBody] UserPreferenceValue preferenceValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = await _userService.GetUser();

            UserPreferenceValue savePreference = null;

            if(preferenceValue.Id == 0)
            {
                // New Value Here
                var newPreference = new UserPreferenceValue()
                {
                    Name = preferenceValue.Name,
                    UserId = user.Id,
                    Value = preferenceValue.Value
                };
            }
            else
            {
                // Update Existing

            }

            return Ok();
        }

    }
}
