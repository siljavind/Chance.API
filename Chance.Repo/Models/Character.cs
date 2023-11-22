using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Character
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Age is required")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Alignment is required")]
    public Alignment Alignment { get; set; }

    public int XP { get; set; } = 0;

    [Required]
    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    public required Race Race { get; set; }

    public int? SubraceId { get; set; }
    [ForeignKey("SubraceId")]
    public required Subrace Subrace { get; set; }

    [Required]
    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    public required Class Class { get; set; }

    [Required]
    public int BackgroundId { get; set; }
    [ForeignKey("BackgroundId")]
    public required Background Background { get; set; }

    [Required]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public required User User { get; set; }

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