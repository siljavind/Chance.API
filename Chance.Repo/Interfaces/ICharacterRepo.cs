using Chance.Repo.Models;

namespace Chance.Repo.Interfaces;

public interface ICharacterRepo
{
    Task<List<Character?>> GetAll();
    Task<Character?> GetById(int id);
    Task<Character> Create(Character character);
    Task<Character> Update(Character character);
    Task<int> Delete(int id);
    Task<bool> Exists(string title);
}
