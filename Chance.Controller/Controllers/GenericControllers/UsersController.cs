using Microsoft.AspNetCore.Mvc;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Chance.Controller.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Chance.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericController<User>
    {
        private readonly IConfiguration _config;
        public UsersController(IGenericRepo<User> repo, IConfiguration config) : base(repo)
        {
            _config = config;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
        {
            if (await _repo.Exists(userRequest.Username))
                return Conflict("Username already exists");

            try
            {
                var newUser = new User { Title = userRequest.Username, Role = Role.User };
                newUser.SetPassword(userRequest.Password);

                var createdUser = await _repo.Create(newUser);

                var token = GenerateJwtToken(createdUser);

                return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, new { token = token });

                //TODO: Set token in cookies instead of returning it in the response body
                // var cookieOptions = new CookieOptions
                // {
                //     HttpOnly = true,
                //     Secure = false, // set to true if your site uses HTTPS
                //     SameSite = SameSiteMode.Strict, // prevents the cookie from being sent in cross-site requests
                //                                     // Expires = DateTime.UtcNow.AddDays(7) // set the cookie to expire after 7 days

                // };

                // Response.Cookies.Append("token", token, cookieOptions);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error registring user: {e.Message}");
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
                    return NotFound("Username not found");

                if (foundUser.CheckPassword(loginRequest.Password))
                    return Ok(new UserResponse { Id = foundUser.Id, Username = foundUser.Title });

                return Unauthorized("Incorrect password");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error logging in: {e.Message}");
                return StatusCode(500, "Something went wrong while logging in");
            }
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"] ?? throw new Exception("JWT Secret Key not found"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new("Id", user.Id.ToString()),
                    new(ClaimTypes.Name, user.Title),
                    new(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generating JWT token: {e.Message}");
                throw new Exception("Error generating token");
            }
        }
    }
}
