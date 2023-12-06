using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    // Abstract class for all immutable controllers
    public abstract class ImmutableController<T> : ControllerBase where T : class, IImmutable
    {
        protected readonly IImmutableRepo<T> _repo;
        public ImmutableController(IImmutableRepo<T> repo)
        {
            _repo = repo;
        }

        // GET: api/[controller]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get() =>
            await _repo.GetAll() is { } entities && entities.Count() != 0 ? Ok(entities) : NotFound();

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T>> Get(int id) =>
            await _repo.GetById(id) is { } entity ? Ok(entity) : NotFound();


        [HttpGet("IdExists/{id}")]
        public async Task<ActionResult<bool>> Exists(int id) => await _repo.Exists(id) ? Ok(true) : NotFound(false);

    }
}

