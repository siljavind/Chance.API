using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Interfaces;

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

        public virtual async Task<ActionResult<List<T>>> Get() =>
            await _repo.GetAll() is { } entities && entities.Count != 0 ? Ok(entities) : NotFound();

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> Get(int id) =>
            await _repo.GetById(id) is { } entity ? Ok(entity) : NotFound();

        // PUT: api/[controller]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public virtual async Task<ActionResult<T>> Post(T entity)
        {
            try
            {
                var createdEntity = await _repo.Create(entity);
                return CreatedAtAction(nameof(Get), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong while creating the entity.");
            }

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
                return NotFound($"The {nameof(T)} could not be found.");
            }
            catch (ConflictException e)
            {
                return Conflict($"A {nameof(T)} with the same title already exists.");
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


    }
}

