using Chance.Repo.Models;

namespace Chance.Repo.Interfaces;

public interface IBackgroundRepo
{
    Task<List<Background>> GetAll();
    Task<Background?> GetById(int id);
    Task<Background> Create(Background background);
    Task<Background> Update(Background background);
    Task<int> Delete(int id);
    Task<bool> Exists(string title);

}
