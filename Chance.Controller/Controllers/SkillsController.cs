using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ImmutableController<Skill> // Using main constructor
    {
        public SkillsController(IImmutableRepo<Skill> repo) : base(repo) { }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public override async Task<ActionResult<Skill>> GetById(int id) =>
            await _repo.GetById(id, s => s.Ability) is { } skill ? Ok(skill) : NotFound();

        // GET: api/Skills
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Skill>>> GetAll() =>
            await _repo.GetAll(s => s.Ability) is { } skills ? Ok(skills) : NotFound();

        [HttpGet("alphabatized")]
        public async Task<IActionResult> GetSkillAlphabatized() =>
            await _repo.GetAll() is { } skills ? Ok(skills.OrderBy(s => s.Title.ToString())) : NotFound();


    }
}
