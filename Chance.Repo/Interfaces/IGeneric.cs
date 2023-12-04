namespace Chance.Repo.Interfaces;

public interface IGeneric
{
    int Id { get; set; }
    string Title { get; set; }
    //TODO Add automatic updated_at, created_at, deleted_at
}
