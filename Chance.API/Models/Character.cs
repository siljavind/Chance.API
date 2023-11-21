using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Character
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public int Age { get; set; }
    public Alignment Alignment { get; set; }
    public int XP { get; set; }
    public Race Race { get; set; }
    public Subrace Subrace { get; set; }
    public Class Class { get; set; }
    public Background Background { get; set; }
    public User User { get; set; }

    [JsonIgnore]
    public List<Ability> Abilities { get; } = [];
}

public enum Alignment
{
    LawfulGood,
    NeutralGood,
    ChaoticGood,
    LawfulNeutral,
    Neutral,
    ChaoticNeutral,
    LawfulEvil,
    NeutralEvil,
    ChaoticEvil
}