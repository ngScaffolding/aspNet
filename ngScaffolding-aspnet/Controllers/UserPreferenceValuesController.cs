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
    public class UserPreferenceValueHolder
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    [Produces("application/json")]
    [Route("api/UserPreferenceValues")]
    public class UserPreferenceValuesController : ngScaffoldingController
    {
        private readonly IRepository<UserPreferenceValue> _userPreferenceRepository;
        private readonly IRepository<UserPreferenceDefinition> _userPreferenceDefinitionRepository;
        private readonly IUserService _userService;

        public UserPreferenceValuesController(IRepository<UserPreferenceValue> userPreferenceRepository,
            IRepository<UserPreferenceDefinition> userPreferenceDefinitionRepository,
            IUserService userService)
        {
            _userPreferenceRepository = userPreferenceRepository;
            _userPreferenceDefinitionRepository = userPreferenceDefinitionRepository;
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

        [HttpDelete("{name}")]
        [Authorize]
        [TypeFilter(typeof(AuditAttribute))]
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            var user = await _userService.GetUser();

            var savePreference = _userPreferenceRepository.GetAll().FirstOrDefault(p => p.UserId == user.Id && p.name == name);

            if(savePreference != null)
            {
                _userPreferenceRepository.Delete(savePreference);
            }

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(AuditAttribute))]
        public async Task<IActionResult> Post([FromBody] UserPreferenceValueHolder preferenceValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUser();

            var savePreference = _userPreferenceRepository.GetAll().FirstOrDefault(p => p.UserId == user.Id && p.name == preferenceValue.Name);
            var definition = _userPreferenceDefinitionRepository.GetAll().FirstOrDefault(p => p.name == preferenceValue.Name);

            if (savePreference == null)
            {
                // New Value Here
                var newPreference = new UserPreferenceValue()
                {
                    name = preferenceValue.Name,
                    UserId = user.Id,
                    Value = preferenceValue.Value,
                    UserPreferenceDefinitionId = definition?.id
                };

                _userPreferenceRepository.Insert(newPreference);
            }
            else
            {
                // Update Existing
                savePreference.Value = preferenceValue.Value;
                _userPreferenceRepository.Update(savePreference);
            }

            return Ok(savePreference);
        }

    }
}
