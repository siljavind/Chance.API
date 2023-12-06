using System.Linq.Expressions;

namespace Chance.Repo.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<T?> GetById(int id, params Expression<Func<T, object>>[] includeProperties);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<int> Delete(int id);
    Task<bool> Exists(string title);
    Task<bool> Exists(int id);

}
