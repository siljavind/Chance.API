using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundsController : GenericController<Background>
    {
        IGenericRepo<Background> _backgroundRepo { get; set; }

        public BackgroundsController(IGenericRepo<Background> repo) : base(repo)
        {
            _backgroundRepo = repo;
        }
    }
}
