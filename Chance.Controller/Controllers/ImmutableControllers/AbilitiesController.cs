using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ImmutableController<Ability>
    {
        public AbilitiesController(IImmutableRepo<Ability> repo) : base(repo) { }

        [HttpGet("alphabatized")]
        public async Task<IActionResult> GetAbilityAlphabatized() =>
            await _repo.GetAll() is { } abilities ? Ok(abilities.OrderBy(a => a.Title.ToString())) : NotFound();
    }
}
// public class AbilitiesController : ControllerBase
//{
//     IImmutableRepo<Ability> AbilityRepo { get; set; }

//     public AbilitiesController(IImmutableRepo<Ability> abilityRepo)
//     {
//         AbilityRepo = abilityRepo;
//     }
//}
