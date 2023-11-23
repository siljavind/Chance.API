
using Chance.Repo.Models;

namespace Chance.Repo.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    T Create(T entity);
    T Update(T entity);
    int Delete(int id);
}

// {
//     List<Ability> GetAll();
//     Ability GetById(int id);
//     Ability Create(Ability ability);
//     Ability Update(Ability ability);
//     int Delete(int id);
// }

