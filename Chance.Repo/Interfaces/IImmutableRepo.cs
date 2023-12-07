using System.Linq.Expressions;

namespace Chance.Repo.Interfaces;

// Represents an interface for an immutable repository.
public interface IImmutableRepo<T> where T : class
{
    // Retrieves all entities of type T from the repository. 
    // The includeProperties parameter allows for eager loading of related entities.
    // It takes a params array of expressions, each specifying a property to include.
    // The 'params' keyword allows the method to take any number of arguments of the specified type.
    // Each argument is an 'Expression<Func<T, object>>', which represents a lambda expression that selects a property of T.
    Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);

    // Retrieves a single entity of type T with the given id from the repository.
    Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);

    // Checks if an entity of type T with the given id exists in the repository.
    Task<bool> Exists(int id);

    Task<int> Count();
}

