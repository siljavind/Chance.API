using Chance.Repo.Data;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Chance.Repo.Repos;

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

    public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties) =>
        await IncludeProperties(includeProperties).ToListAsync() ?? throw new NotFoundException($"{typeof(T).Name} not found");

    public async Task<T?> GetById(int id, params Expression<Func<T, object>>[] includeProperties) =>
        await IncludeProperties(includeProperties).SingleOrDefaultAsync(e => e.Id == id) ?? throw new NotFoundException($"{typeof(T).Name} with id {id} not found");

    public async Task<bool> Exists(int id) => await _dbSet.AnyAsync(e => e.Id == id);

    private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.AsQueryable();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }
}
