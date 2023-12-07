// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Chance.Repo.Data;
// using Chance.Repo.Models;
// using Chance.Repo.Interfaces;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Chance.Repo.DTOs;

// namespace Chance.Controller.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class CharactersController : ControllerBase
//     {
//         ICharacterRepo CharacterRepo { get; set; }
//         public CharactersController(ICharacterRepo characterRepo)
//         {
//             CharacterRepo = characterRepo;
//         }

//         // GET: api/Characters
//         [HttpGet]
//         public async Task<ActionResult<List<Character>>> GetCharacter() =>
//             await CharacterRepo.GetAll() is { } characters && characters.Count != 0 ? Ok(characters) : NotFound();

//         // GET: api/Characters/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Character>> GetCharacter(int id) =>
//             await CharacterRepo.GetById(id) is { } character ? Ok(character) : NotFound();

//         // POST: api/Characters
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<Character>> PostCharacter(Character character)
//         {
//             try
//             {
//                 var createdCharacter = await CharacterRepo.Create(character);
//                 return CreatedAtAction("GetCharacter", new { id = createdCharacter.Id }, createdCharacter);
//             }
//             catch (Exception)
//             {
//                 return BadRequest("Character could not be created.");
//             }
//         }
//         // PUT: api/Characters/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutCharacter(int id, Character character)
//         {
//             if (id != character.Id)
//                 return BadRequest();

//             try
//             {
//                 var updatedCharacter = await CharacterRepo.Update(character);
//                 return Ok(updatedCharacter);
//             }
//             catch (NotFoundException)
//             {
//                 return NotFound($"The character could not be found.");
//             }
//             catch (Exception)
//             {
//                 return StatusCode(500, "Something went wrong while updating the entity.");
//             }
//         }

//         // DELETE: api/Characters/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteCharacter(int id)
//         {
//             try
//             {
//                 await CharacterRepo.Delete(id);
//                 return NoContent();
//             }
//             catch (NotFoundException)
//             {
//                 return NotFound($"The character could not be found.");
//             }
//             catch (Exception)
//             {
//                 return StatusCode(500, "Something went wrong while deleting the entity.");
//             }
//         }
//     }
// }
