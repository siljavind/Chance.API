using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos;

public class AbilitiesRepo : IAbilitiesRepo
{
    ChanceDbContext _context;

    public AbilitiesRepo(ChanceDbContext context)
    {
        _context = context;
    }

    public List<Ability> GetAll() => _context.Abilities.ToList();

    public Ability Create(Ability ability)
    {
        _context.Abilities.Add(ability);
        _context.SaveChanges();
        return ability;
    }

    public int Delete(int id) => _context.Abilities.Where(a => a.Id == id).ExecuteDelete();
    //{
    //    return _context.Abilities.Where(a => a.Id == id).ExecuteDelete();
    //}               

    public Ability GetById(int id) => _context.Abilities.Single(a => a.Id == id);

    public Ability Update(Ability ability)
    {
        throw new NotImplementedException();
    }
}
