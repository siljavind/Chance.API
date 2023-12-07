using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericController<User>
    {
        public UsersController(IGenericRepo<User> repo) : base(repo) { }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            if (await _repo.Exists(user.Title))
                return Conflict("A user with that title already exists.");

            try
            {
                user.SetPassword(user.PasswordHash);
                var createdUser = await _repo.Create(user);
                return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
                //return StatusCode(500, "Something went wrong while creating the user.");
            }
        }
    }
}
