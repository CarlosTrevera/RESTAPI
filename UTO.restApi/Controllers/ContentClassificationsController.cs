using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTO.restApi.Models;

namespace UTO.restApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentClassificationsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ContentClassificationsController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentClassifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentClassification>>> GetContentClassification()
        {
            return await _context.ContentClassification.ToListAsync();
        }

        // GET: api/ContentClassifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentClassification>> GetContentClassification(Guid id)
        {
            var contentClassification = await _context.ContentClassification.FindAsync(id);

            if (contentClassification == null)
            {
                return NotFound();
            }

            return contentClassification;
        }

        // PUT: api/ContentClassifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentClassification(Guid id, ContentClassification contentClassification)
        {
            if (id != contentClassification.ContectClassificationId)
            {
                return BadRequest();
            }

            _context.Entry(contentClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentClassificationExists(id))
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

        // POST: api/ContentClassifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentClassification>> PostContentClassification(ContentClassification contentClassification)
        {
            _context.ContentClassification.Add(contentClassification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentClassification", new { id = contentClassification.ContectClassificationId }, contentClassification);
        }

        // DELETE: api/ContentClassifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentClassification(Guid id)
        {
            var contentClassification = await _context.ContentClassification.FindAsync(id);
            if (contentClassification == null)
            {
                return NotFound();
            }

            _context.ContentClassification.Remove(contentClassification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentClassificationExists(Guid id)
        {
            return _context.ContentClassification.Any(e => e.ContectClassificationId == id);
        }
    }
}
