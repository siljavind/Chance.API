using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubracesController : GenericController<Subrace>
    {
        public SubracesController(IGenericRepo<Subrace> repo) : base(repo) { }

        [HttpGet]
        public override async Task<ActionResult<List<Subrace>>> Get() =>
            await _repo.GetAll(s => s.Ability, s => s.Race) is { } subraces ? Ok(subraces) : NotFound();

        [HttpGet("{id}")]
        public override async Task<ActionResult<Subrace>> Get(int id) =>
            await _repo.GetById(id, s => s.Ability, s => s.Race) is { } subrace ? Ok(subrace) : NotFound();


        // [HttpGet("{id}")]
        // public override async Task<ActionResult<Subrace>> GetById(int id) =>
        //     throw new NotImplementedException();
    }
}
