using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ngScaffolding.database;
using ngScaffolding.database.Models;
using ngScaffolding.Data;

namespace ngScaffolding.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ErrorsController : Controller
    {
        private readonly ngScaffoldingContext _context;

        public ErrorsController(ngScaffoldingContext context)
        {
            _context = context;
        }

        // POST: api/MenuItems
        [HttpPost]
        public async Task<IActionResult> PostErrorModel([FromBody] ErrorModel errorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Errors.Add(errorModel);
            await _context.SaveChangesAsync();

            return Ok(new { id = errorModel.Id });
        }
    }
}
