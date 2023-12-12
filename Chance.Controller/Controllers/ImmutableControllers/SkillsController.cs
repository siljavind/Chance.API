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

        [HttpGet("Alphabatized")]
        public async Task<IActionResult> GetSkillAlphabatized() =>
            await _repo.GetAll() is { } skills ? Ok(skills.OrderBy(s => s.Title.ToString())) : NotFound();

        public override Expression<Func<Skill, object>>[] GetIncludes()
        {
            return [s => s.Ability];
        }
    }
}
