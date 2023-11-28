using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Chance.Repo.Interfaces;

namespace Chance.Repo.Models;

public class Ability : IImmutable
{
    [Key]
    public int Id { get; set; }

    public AbilityType Title { get; set; }

    [JsonIgnore]
    public List<Class> Classes { get; set; } = [];

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];

    [JsonIgnore]
    public List<Race> Races { get; set; } = [];

    [JsonIgnore]
    public List<Subrace> Subraces { get; set; } = [];

    [JsonIgnore]
    public List<Skill> Skills { get; set; } = [];
}

public enum AbilityType
{
    Strength = 1,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}