using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Ability
{
    [Key]
    public AbilityType AbilityType { get; set; }

    [JsonIgnore]
    public List<Class> Classes { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; set; }

    [JsonIgnore]
    public List<Race> Races { get; set; }

    [JsonIgnore]
    public List<Subrace> Subraces { get; set; }

    [JsonIgnore]
    public List<Skill> Skills { get; set; }
}

public enum AbilityType
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}