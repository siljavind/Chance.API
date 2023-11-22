using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Data;
using Chance.Repo.Models;

namespace Chance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundsController : ControllerBase
    {
        private readonly ChanceDbContext _context;

        public BackgroundsController(ChanceDbContext context)
        {
            _context = context;
        }

        // GET: api/Backgrounds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Background>>> GetBackground()
        {
            return await _context.Backgrounds.ToListAsync();
        }

        // GET: api/Backgrounds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Background>> GetBackground(int id)
        {
            var background = await _context.Backgrounds.FindAsync(id);

            if (background == null)
            {
                return NotFound();
            }

            return background;
        }

        // PUT: api/Backgrounds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBackground(int id, Background background)
        {
            if (id != background.Id)
            {
                return BadRequest();
            }

            _context.Entry(background).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BackgroundExists(id))
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

        // POST: api/Backgrounds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Background>> PostBackground(Background background)
        {
            _context.Backgrounds.Add(background);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBackground", new { id = background.Id }, background);
        }

        // DELETE: api/Backgrounds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBackground(int id)
        {
            var background = await _context.Backgrounds.FindAsync(id);
            if (background == null)
            {
                return NotFound();
            }

            _context.Backgrounds.Remove(background);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BackgroundExists(int id)
        {
            return _context.Backgrounds.Any(e => e.Id == id);
        }
    }
}
