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
    public class ContentTypesController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ContentTypesController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentType>>> GetContentType()
        {
            return await _context.ContentType.ToListAsync();
        }

        // GET: api/ContentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentType>> GetContentType(Guid id)
        {
            var contentType = await _context.ContentType.FindAsync(id);

            if (contentType == null)
            {
                return NotFound();
            }

            return contentType;
        }

        // PUT: api/ContentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentType(Guid id, ContentType contentType)
        {
            if (id != contentType.ContentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(contentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentTypeExists(id))
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

        // POST: api/ContentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentType>> PostContentType(ContentType contentType)
        {
            _context.ContentType.Add(contentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentType", new { id = contentType.ContentTypeId }, contentType);
        }

        // DELETE: api/ContentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentType(Guid id)
        {
            var contentType = await _context.ContentType.FindAsync(id);
            if (contentType == null)
            {
                return NotFound();
            }

            _context.ContentType.Remove(contentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentTypeExists(Guid id)
        {
            return _context.ContentType.Any(e => e.ContentTypeId == id);
        }
    }
}
