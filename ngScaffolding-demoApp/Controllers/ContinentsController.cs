using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngScacffolding.demoApp.Data;
using ngScaffolding.demoApp.Models;

namespace ngScaffolding_demoApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Continents")]
    public class ContinentsController : Controller
    {
        private readonly DemoContext _context;

        public ContinentsController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Continents
        [HttpGet]
        public IEnumerable<Continent> GetContinents()
        {
            return _context.Continents;
        }

        // GET: api/Continents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContinent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var continent = await _context.Continents.SingleOrDefaultAsync(m => m.Id == id);

            if (continent == null)
            {
                return NotFound();
            }

            return Ok(continent);
        }

        // PUT: api/Continents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContinent([FromRoute] int id, [FromBody] Continent continent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != continent.Id)
            {
                return BadRequest();
            }

            _context.Entry(continent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Continents
        [HttpPost]
        public async Task<IActionResult> PostContinent([FromBody] Continent continent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Continents.Add(continent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContinent", new { id = continent.Id }, continent);
        }

        // DELETE: api/Continents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContinent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var continent = await _context.Continents.SingleOrDefaultAsync(m => m.Id == id);
            if (continent == null)
            {
                return NotFound();
            }

            _context.Continents.Remove(continent);
            await _context.SaveChangesAsync();

            return Ok(continent);
        }

        private bool ContinentExists(int id)
        {
            return _context.Continents.Any(e => e.Id == id);
        }
    }
}