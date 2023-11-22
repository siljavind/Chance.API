
using Chance.Repo.Models;

namespace Chance.Repo.Interfaces;

public interface IAbilitiesRepo
{
    List<Ability> GetAll();
    Ability GetById(int id);
    Ability Create(Ability ability);
    Ability Update(Ability ability);
    int Delete(int id);
}

