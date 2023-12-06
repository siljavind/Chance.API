using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : GenericController<Race>
    {
        public RacesController(IGenericRepo<Race> repo) : base(repo) { }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Race>>> GetAll() =>
            await _repo.GetAll(r => r.Ability) is { } ability ? Ok(ability) : NotFound();

        [HttpGet("{id}")]
        public override async Task<ActionResult<Race>> GetById(int id) =>
            await _repo.GetById(id, r => r.Ability) is { } ability ? Ok(ability) : NotFound();
    }
}
