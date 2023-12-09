using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Chance.Controller.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericController<User>
    {
        public UsersController(IGenericRepo<User> repo) : base(repo) { }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserResponse>> Register([FromBody] UserRequest userRequest)
        {
            if (await _repo.Exists(userRequest.Username))
                return Conflict("A user with that username already exists.");

            try
            {
                var newUser = new User { Title = userRequest.Username, Role = Role.User };
                newUser.SetPassword(userRequest.Password);

                var createdUser = await _repo.Create(newUser);

                UserResponse userResponse = new()
                {
                    Id = createdUser.Id,
                    Username = createdUser.Title
                };

                return CreatedAtAction(nameof(Get), new { id = userResponse.Id }, userResponse);
            }
            catch (Exception e)
            {
                //return Problem(e.Message);
                return StatusCode(500, "Something went wrong while creating the user.");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login([FromBody] UserRequest loginRequest)
        {
            try
            {
                var foundUser = await _repo.GetByTitle(loginRequest.Username);

                if (foundUser is null)
                    return NotFound("No user with that title exists.");

                if (foundUser.CheckPassword(loginRequest.Password))
                    return Ok(new UserResponse { Id = foundUser.Id, Username = foundUser.Title });

                return Unauthorized("Incorrect password.");
            }
            catch (Exception e)
            {
                //return Problem(e.Message);
                return StatusCode(500, "Something went wrong while logging in.");
            }
        }
    }
}
