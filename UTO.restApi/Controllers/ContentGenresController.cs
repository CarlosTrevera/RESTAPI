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
    public class ContentGenresController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ContentGenresController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/ContentGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentGenre>>> GetContentGenre()
        {
            return await _context.ContentGenre.ToListAsync();
        }

        // GET: api/ContentGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentGenre>> GetContentGenre(Guid id)
        {
            var contentGenre = await _context.ContentGenre.FindAsync(id);

            if (contentGenre == null)
            {
                return NotFound();
            }

            return contentGenre;
        }

        // PUT: api/ContentGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentGenre(Guid id, ContentGenre contentGenre)
        {
            if (id != contentGenre.ContentGenreId)
            {
                return BadRequest();
            }

            _context.Entry(contentGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentGenreExists(id))
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

        // POST: api/ContentGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentGenre>> PostContentGenre(ContentGenre contentGenre)
        {
            _context.ContentGenre.Add(contentGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentGenre", new { id = contentGenre.ContentGenreId }, contentGenre);
        }

        // DELETE: api/ContentGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentGenre(Guid id)
        {
            var contentGenre = await _context.ContentGenre.FindAsync(id);
            if (contentGenre == null)
            {
                return NotFound();
            }

            _context.ContentGenre.Remove(contentGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentGenreExists(Guid id)
        {
            return _context.ContentGenre.Any(e => e.ContentGenreId == id);
        }
    }
}
