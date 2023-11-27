using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Ability
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [Column(TypeName = "nvarchar(15)")]
    public AbilityType Title { get; set; }

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
    Strength = 1,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma
}