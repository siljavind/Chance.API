using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Repos.Immutables;

// Represents a generic repository for immutable entities.
public class ImmutableRepo<T> : IImmutableRepo<T> where T : class, IImmutable
{
    protected readonly ChanceDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public ImmutableRepo(ChanceDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

    public async Task<T?> GetById(int id) => await _dbSet.SingleAsync(e => e.Id == id);

    // public async Task<List<Skill>> GetAll()
    // {
    //     return await _context.Skills.ToListAsync();
    // }

    // public async Task<Skill> GetById(int id)
    // {
    //     return await _context.Skills.SingleAsync(s => s.SkillType == (SkillType)id);
    // }
}
