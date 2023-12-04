namespace Chance.Repo.Interfaces;

public interface IGenericRepo<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<int> Delete(int id);
    Task<bool> Exists(string title);
    Task<bool> Exists(int id);

}
