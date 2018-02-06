using Microsoft.AspNetCore.Mvc;

namespace ngScaffolding.Controllers
{
    [Produces("application/json")]
    [Route("api/ReferenceValues1")]
    public class ReferenceValues1Controller : Controller
    {
        //    private readonly ngScaffoldingContext22 _context;

        //    public ReferenceValues1Controller(ngScaffoldingContext22 context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/ReferenceValues1
        //    [HttpGet]
        //    public IEnumerable<ReferenceValue> GetReferenceValue()
        //    {
        //        return _context.ReferenceValue;
        //    }

        //    // GET: api/ReferenceValues1/5
        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetReferenceValue([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var referenceValue = await _context.ReferenceValue.SingleOrDefaultAsync(m => m.Id == id);

        //        if (referenceValue == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(referenceValue);
        //    }

        //    // PUT: api/ReferenceValues1/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutReferenceValue([FromRoute] int id, [FromBody] ReferenceValue referenceValue)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != referenceValue.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(referenceValue).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReferenceValueExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/ReferenceValues1
        //    [HttpPost]
        //    public async Task<IActionResult> PostReferenceValue([FromBody] ReferenceValue referenceValue)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _context.ReferenceValue.Add(referenceValue);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetReferenceValue", new { id = referenceValue.Id }, referenceValue);
        //    }

        //    // DELETE: api/ReferenceValues1/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteReferenceValue([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var referenceValue = await _context.ReferenceValue.SingleOrDefaultAsync(m => m.Id == id);
        //        if (referenceValue == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.ReferenceValue.Remove(referenceValue);
        //        await _context.SaveChangesAsync();

        //        return Ok(referenceValue);
        //    }

        //    private bool ReferenceValueExists(int id)
        //    {
        //        return _context.ReferenceValue.Any(e => e.Id == id);
        //    }
        //}
    }
}