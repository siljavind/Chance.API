using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos.Immutables;

/// <summary>
/// Represents a generic repository for immutable entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public class ImmutableRepo<T> : IImmutableRepo<T> where T : class
{
    protected readonly ChanceDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public ImmutableRepo(ChanceDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

    public async Task<T?> GetById(int id)
    {
        if (typeof(T) == typeof(Ability))
            return await _context.Set<Ability>().SingleAsync(a => a.Id == (AbilityType)id) as T;

        if (typeof(T) == typeof(Skill))
            return await _context.Set<Skill>().SingleAsync(s => s.Id == (SkillType)id) as T;

        return null;
    }

    // public async Task<List<Skill>> GetAll()
    // {
    //     return await _context.Skills.ToListAsync();
    // }

    // public async Task<Skill> GetById(int id)
    // {
    //     return await _context.Skills.SingleAsync(s => s.SkillType == (SkillType)id);
    // }
}
