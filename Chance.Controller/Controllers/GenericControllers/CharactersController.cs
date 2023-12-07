using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : GenericController<Character>
    {
        public CharactersController(IGenericRepo<Character> repo) : base(repo) { }

        [HttpGet]
        public async override Task<ActionResult<List<Character>>> Get() =>
            await _repo.GetAll(
                c => c.Race,
                c => c.Subrace,
                c => c.Class,
                c => c.Background,
                c => c.User
                ) is { } characters ? Ok(characters) : NotFound();

        [HttpGet("{id}")]
        public async override Task<ActionResult<Character>> Get(int id) =>
            await _repo.GetById(
                id,
                c => c.Race,
                c => c.Subrace,
                c => c.Class,
                c => c.Background,
                c => c.User
                ) is { } characters ? Ok(characters) : NotFound();
    }
}
