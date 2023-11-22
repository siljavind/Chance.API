using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

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

    [Required]
    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    public Race Race { get; set; }

    public int? SubraceId { get; set; }
    [ForeignKey("SubraceId")]
    public Subrace Subrace { get; set; }

    [Required]
    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    public Class Class { get; set; }

    [Required]
    public int BackgroundId { get; set; }
    [ForeignKey("BackgroundId")]
    public Background Background { get; set; }

    [Required]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
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