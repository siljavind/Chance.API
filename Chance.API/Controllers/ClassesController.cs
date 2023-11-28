using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        IGenericRepo<Class> _classRepo { get; set; }

        public ClassesController(IGenericRepo<Class> classRepo)
        {
            _classRepo = classRepo;
        }

        // GET: api/Classes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Class>>> GetClass() => await _classRepo.GetAll();

        // GET: api/Classes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Class>> GetClass(int id) => await _classRepo.GetById(id) is { } classParam ? Ok(classParam) : NotFound();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Class>> PostClass(Class classParam)
        {
            var classParamExists = await _classRepo.TitleExists(classParam.Title);

            if (classParamExists)
                return Conflict("A class with the same title already exists.");

            await _classRepo.Create(classParam);

            return CreatedAtAction("GetClass", new { id = classParam.Id }, classParam);
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutClass(int id, Class classParam)
        {
            if (id != classParam.Id)
                return BadRequest();

            var updatedClass = await _classRepo.Update(classParam);

            return Ok(updatedClass);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClass(int id) => await _classRepo.Delete(id) != 0 ? NoContent() : NotFound();
    }
}
