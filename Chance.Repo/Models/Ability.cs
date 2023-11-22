using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Ability
{
    [Key]
    public int Id { get; set; }

    public AbilityType AbilityType { get; set; }

    [JsonIgnore]
    public List<Class> Classes { get; } = [];

    [JsonIgnore]
    public List<Character> Characters { get; } = [];

}

public enum AbilityType //TODO Is this the best way to do this?
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}