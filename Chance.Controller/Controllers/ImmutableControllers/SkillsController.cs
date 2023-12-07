using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using System.Linq.Expressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ImmutableController<Skill>
    {
        public SkillsController(IImmutableRepo<Skill> repo) : base(repo) { }

        // GET: api/Skills
        [HttpGet]
        public override async Task<ActionResult<List<Skill>>> Get() =>
            await _repo.GetAll(s => s.Ability) is { } skills ? Ok(skills) : NotFound();

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public override async Task<ActionResult<Skill>> Get(int id) =>
            await _repo.GetById(id, s => s.Ability) is { } skill ? Ok(skill) : NotFound();

        [HttpGet("alphabatized")]
        public async Task<IActionResult> GetSkillAlphabatized() =>
            await _repo.GetAll() is { } skills ? Ok(skills.OrderBy(s => s.Title.ToString())) : NotFound();


    }
}
