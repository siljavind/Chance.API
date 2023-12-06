using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : GenericController<Class>
    {
        public ClassesController(IGenericRepo<Class> repo) : base(repo) { }
    }
}
