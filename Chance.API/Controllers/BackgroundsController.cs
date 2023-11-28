using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundsController : ControllerBase
    {
        //IBackgroundRepo _backgroundRepo { get; set; }
        IGenericRepo<Background> _backgroundRepo { get; set; }
        //private readonly ChanceDbContext _context;

        public BackgroundsController(IGenericRepo<Background> backgroundRepo)
        {
            _backgroundRepo = backgroundRepo;
            // _context = context;
        }

        // GET: api/Backgrounds
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Background>>> GetBackground() => await _backgroundRepo.GetAll();

        // GET: api/Backgrounds/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Background>> GetBackground(int id) => await _backgroundRepo.GetById(id) is { } background ? Ok(background) : NotFound();
        // {
        //     var background = await _backgroundRepo.GetById(id);

        //     if (background == null)
        //     {
        //         return NotFound();
        //     }

        //     // Return the background (Ok() is unnecessary, but it's good practice to be explicit)
        //     return Ok(background);
        // }

        // POST: api/Backgrounds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Background>> PostBackground(Background background)
        {
            try
            {
                await _backgroundRepo.Create(background);
                return CreatedAtAction("GetBackground", new { id = background.Id }, background);
            }
            catch (Exception)
            {
                return Conflict("A background with the same title already exists.");
            }
            // var backgroundExists = await _backgroundRepo.TitleExists(background.Title);

            // if (backgroundExists)
            //     return Conflict("A background with the same title already exists.");

            // await _backgroundRepo.Create(background);

            // return CreatedAtAction("GetBackground", new { id = background.Id }, background);
        }

        // PUT: api/Backgrounds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutBackground(int id, Background background)
        {
            if (id != background.Id)
                return BadRequest();

            var updatedBackground = await _backgroundRepo.Update(background);

            return Ok(updatedBackground);
        }

        // DELETE: api/Backgrounds/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBackground(int id) => await _backgroundRepo.Delete(id) != 0 ? NoContent() : NotFound();
    }
}
