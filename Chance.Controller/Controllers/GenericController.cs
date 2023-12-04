using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Chance.Repo.Repos;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class GenericController<T> : ControllerBase where T : class, IGeneric
    {
        private readonly IGenericRepo<T> _repo;
        public GenericController(IGenericRepo<T> repo)
        {
            _repo = repo;
        }

        // GET: api/[controller]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<T>>> GetAll() =>
            await _repo.GetAll() is { } entities ? Ok(entities) : NotFound();

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<T>> GetById(int id) =>
            await _repo.GetById(id) is { } entity ? Ok(entity) : NotFound();

        // PUT: api/[controller]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<T>> Post(T entity)
        {
            if (await _repo.Exists(entity.Title))
                return Conflict("An entity with the same title already exists.");

            await _repo.Create(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, T entity)
        {
            if (id != entity.Id)
                return BadRequest();

            try
            {
                return Ok(await _repo.Update(entity));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id) => await _repo.Delete(id) == 1 ? NoContent() : NotFound();

        [HttpGet("TitleExists/{title}")]
        public async Task<ActionResult<bool>> TitleExists(string title) => await _repo.Exists(title) ? Ok(true) : NotFound(false);

        [HttpGet("IdExists/{id}")]
        public async Task<ActionResult<bool>> IdExists(int id) => await _repo.Exists(id) ? Ok(true) : NotFound(false);


    }
}

