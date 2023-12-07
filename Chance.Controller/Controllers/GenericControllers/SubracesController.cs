using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using System.Linq.Expressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubracesController : GenericController<Subrace>
    {
        public SubracesController(IGenericRepo<Subrace> repo) : base(repo) { }

        public override Expression<Func<Subrace, object>>[] GetIncludes()
        {
            return [s => s.Ability, s => s.Race];
        }
    }
}
