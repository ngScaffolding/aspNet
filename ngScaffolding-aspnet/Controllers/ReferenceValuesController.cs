using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ngScaffolding.ExtensionMethods;
using ngScaffolding.Services;
using ngScaffolding.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using ngScaffolding.database.Models;

namespace ngScaffolding.Controllers
{
    [Route("api/ReferenceValues")]
    public class ReferenceValuesController : ngScaffoldingController
    {
        private readonly IReferenceValuesService _referenceValuesService;
        private readonly IUserService _userService;

        public ReferenceValuesController(IReferenceValuesService referenceValuesService, IUserService userService)
        {
            _referenceValuesService = referenceValuesService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [TypeFilter(typeof(AuditAttribute))]
        public IActionResult Get(string name, string seed = null, string group = null)
        {
            var user = _userService.GetUser();

            ReferenceValue retVal = null;

            if (!StringChecker.IsNullOrEmpty(name) && !StringChecker.IsNullOrEmpty(seed))
            {
                retVal = _referenceValuesService.GetValue(name, seed);
            }
            else if (!StringChecker.IsNullOrEmpty(name))
            {
                retVal = _referenceValuesService.GetValue(name);
            }
            else if (!StringChecker.IsNullOrEmpty(group))
            {
                return Ok(_referenceValuesService.GetGroup(group));
            }

            if (retVal != null)
            {
                retVal.CleanForClient();
                return Ok(retVal);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/ReferenceValues
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReferenceValues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
