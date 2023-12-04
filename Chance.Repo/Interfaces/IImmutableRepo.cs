using System.Linq.Expressions;

namespace Chance.Repo.Interfaces;

// Represents an interface for an immutable repository.
public interface IImmutableRepo<T> where T : class
{
    Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<T?> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
    Task<bool> Exists(int id);
}

