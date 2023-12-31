using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Chance.Repo.Interfaces;

namespace Chance.Repo.Models;

public class Character : IGeneric
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Age is required")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Alignment is required")]
    public Alignment Alignment { get; set; }

    public int XP { get; set; } = 0;

    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    public Race? Race { get; set; }

    public int SubraceId { get; set; }
    [ForeignKey("SubraceId")]
    public Subrace? Subrace { get; set; }

    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    public Class? Class { get; set; }

    public int BackgroundId { get; set; }
    [ForeignKey("BackgroundId")]
    public Background? Background { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }

    [JsonIgnore]
    public List<Ability> Abilities { get; set; } = [];
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