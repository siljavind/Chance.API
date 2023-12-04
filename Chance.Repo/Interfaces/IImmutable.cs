namespace Chance.Repo.Interfaces;

public interface IImmutable
{
    int Id { get; set; }
    //TODO Add automatic updated_at, created_at, deleted_at
}
