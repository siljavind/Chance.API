using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos;

public class AbilityRepo : IRepository<Ability>
{
    ChanceDbContext _context;

    public AbilityRepo(ChanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ability>> GetAll()
    {
        return await _context.Abilities.ToListAsync();
    }

    public async Task<Ability> GetById(int id) => await _context.Abilities.SingleAsync(a => a.AbilityType == (AbilityType)id);

    public async Task<Ability> GetByAbilityType(int abilityType) => await _context.Abilities.SingleAsync(a => a.AbilityType == (AbilityType)abilityType);

    public Ability Create(Ability ability)
    {
        _context.Abilities.Add(ability);
        _context.SaveChanges();
        return ability;
    }

    public Ability Update(Ability ability)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id) => _context.Abilities.Where(a => a.AbilityType == (AbilityType)id).ExecuteDelete();

}
