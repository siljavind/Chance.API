using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ClassesController : GenericController<Class>
    {
        IGenericRepo<Class> _classRepo { get; set; }

        public ClassesController(IGenericRepo<Class> repo) : base(repo)
        {
            _classRepo = repo;
        }
    }
}
