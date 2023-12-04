using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Data;
using Chance.Repo.Models;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubracesController : ControllerBase
    {
        private readonly ChanceDbContext _context;

        public SubracesController(ChanceDbContext context)
        {
            _context = context;
        }

        // GET: api/Subraces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subrace>>> GetSubrace()
        {
            return await _context.Subraces.ToListAsync();
        }

        // GET: api/Subraces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subrace>> GetSubrace(int id)
        {
            var subrace = await _context.Subraces.FindAsync(id);

            if (subrace == null)
            {
                return NotFound();
            }

            return subrace;
        }

        // PUT: api/Subraces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubrace(int id, Subrace subrace)
        {
            if (id != subrace.Id)
            {
                return BadRequest();
            }

            _context.Entry(subrace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubraceExists(id))
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

        // POST: api/Subraces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subrace>> PostSubrace(Subrace subrace)
        {
            _context.Subraces.Add(subrace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubrace", new { id = subrace.Id }, subrace);
        }

        // DELETE: api/Subraces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubrace(int id)
        {
            var subrace = await _context.Subraces.FindAsync(id);
            if (subrace == null)
            {
                return NotFound();
            }

            _context.Subraces.Remove(subrace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubraceExists(int id)
        {
            return _context.Subraces.Any(e => e.Id == id);
        }
    }
}
