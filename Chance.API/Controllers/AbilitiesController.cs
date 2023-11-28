using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;

namespace Chance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        IImmutableRepo<Ability> AbilityRepo { get; set; }

        public AbilitiesController(IImmutableRepo<Ability> abilityRepo)
        {
            AbilityRepo = abilityRepo;
        }

        // GET: api/Abilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbility() => await AbilityRepo.GetAll();

        // GET: api/Abilities/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAbility(int id) => await AbilityRepo.GetById(id) is { } ability ? Ok(ability) : NotFound();



        // POST: api/Abilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Ability>> PostAbility(Ability ability)
        // {
        //     if (ability == null) return BadRequest();

        //     AbilityRepo.GetByAbilityType(ability);

        //     AbilityRepo.Create(ability);
        //     _context.Abilities.Add(ability);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetAbility", new { id = ability.Id }, ability);
        // }

        // PUT: api/Abilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutAbility(int id, Ability ability)
        // {
        //     if (id != ability.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(ability).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!AbilityExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }


        // // DELETE: api/Abilities/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteAbility(int id)
        // {
        //     var ability = await _context.Abilities.FindAsync(id);
        //     if (ability == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Abilities.Remove(ability);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool AbilityExists(int id)
        // {
        //     return _context.Abilities.Any(e => e.Id == id);
        // }
    }
}
