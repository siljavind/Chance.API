using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Interfaces;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public abstract class GenericController<T> : ControllerBase where T : class, IGeneric
    {
        protected readonly IGenericRepo<T> _repo;
        public GenericController(IGenericRepo<T> repo)
        {
            _repo = repo;
        }

        // GET: api/[controller]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public virtual async Task<ActionResult<List<T>>> Get()
        {
            try
            {
                return Ok(await _repo.GetAll(GetIncludes()));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> Get([FromQuery] int id)
        {
            try
            {
                return Ok(await _repo.GetById(id, GetIncludes()));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{title}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> Get([FromQuery] string title)
        {
            try
            {
                return Ok(await _repo.GetByTitle(title, GetIncludes()));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/[controller]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public virtual async Task<ActionResult<T>> Post([FromBody] T entity)
        {
            try
            {
                var createdEntity = await _repo.Create(entity);
                return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
            }
            catch (ConflictException e)
            {
                return Conflict($"{typeof(T).Name} already exists.");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<T>> Put([FromQuery] int id, [FromBody] T entity)
        {
            // if (id != entity.Id) //TODO Add check if user is admin and skip check if so
            //     return BadRequest();

            try
            {
                return Ok(await _repo.Update(entity));
            }
            catch (NotFoundException e)
            {
                return NotFound($"{typeof(T).Name} could not be found.");
            }
            catch (ConflictException e)
            {
                return Conflict($"{typeof(T).Name} already exists.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Something went wrong while updating the entity.");
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

        [NonAction]
        public virtual Expression<Func<T, object>>[] GetIncludes()
        {
            return [];
        }
    }
}

