using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Character
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Age is required")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Alignment is required")]
    public Alignment Alignment { get; set; }

    public int XP { get; set; } = 0;

    [ForeignKey("Race")]
    public int RaceId { get; set; }
    public Race Race { get; set; }

    [ForeignKey("Subrace")]
    public int SubraceId { get; set; }
    public Subrace Subrace { get; set; }

    [ForeignKey("Class")]
    public int ClassId { get; set; }
    public Class Class { get; set; }

    [ForeignKey("Background")]
    public int BackgroundId { get; set; }
    public Background Background { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }

    [JsonIgnore]
    public List<Ability> Abilities { get; set; }
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