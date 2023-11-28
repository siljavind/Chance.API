namespace Chance.Repo.Interfaces;

// Represents an interface for an immutable repository.
public interface IImmutableRepo<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
}

