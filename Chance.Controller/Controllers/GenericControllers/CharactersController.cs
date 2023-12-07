using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using System.Linq.Expressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : GenericController<Character>
    {
        public CharactersController(IGenericRepo<Character> repo) : base(repo) { }

        public override Expression<Func<Character, object>>[] GetIncludes()
        {
            return [c => c.Race, c => c.Subrace, c => c.Class, c => c.Background, c => c.User];
        }
    }
}
