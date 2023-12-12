using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Interfaces;
using System.Linq.Expressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public abstract class ImmutableController<T> : ControllerBase where T : class, IImmutable
    {
        protected readonly IImmutableRepo<T> _repo;
        public ImmutableController(IImmutableRepo<T> repo)
        {
            _repo = repo;
        }

        // GET: api/[controller]
        [HttpGet]
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
        public virtual async Task<ActionResult<T>> Get(int id)
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


        [HttpGet("IdExists/{id}")]
        public async Task<ActionResult<bool>> Exists(int id) =>
            await _repo.Exists(id) ? Ok(true) : NotFound(false);

        [HttpGet("Count")]
        public async Task<ActionResult<int>> Count() =>
            await _repo.Count();

        [NonAction]
        public virtual Expression<Func<T, object>>[] GetIncludes()
        {
            return [];
        }
    }
}

