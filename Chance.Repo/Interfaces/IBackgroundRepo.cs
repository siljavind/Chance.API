using Chance.Repo.Models;

namespace Chance.Repo.Interfaces;

public interface IBackgroundRepo
{
    List<Background> GetAll();
    Background GetById(int id);
    Background Create(Background background);
    Background Update(Background background);
    int Delete(int id);
}
