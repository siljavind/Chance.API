using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RacesController : GenericController<Race>
    {
        IGenericRepo<Race> _raceRepo { get; set; }

        public RacesController(IGenericRepo<Race> repo) : base(repo)
        {
            _raceRepo = repo;
        }
    }
}
