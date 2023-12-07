using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using System.Linq.Expressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : GenericController<Race>
    {
        public RacesController(IGenericRepo<Race> repo) : base(repo) { }

        public override Expression<Func<Race, object>>[] GetIncludes()
        {
            return [r => r.Ability];
        }
    }
}
