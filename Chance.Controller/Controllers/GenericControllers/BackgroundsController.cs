using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundsController : GenericController<Background>
    {
        public BackgroundsController(IGenericRepo<Background> repo) : base(repo) { }
    }
}
