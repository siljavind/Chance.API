using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Subrace
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required]
    public int IncreaseAbilityId { get; set; }
    [ForeignKey("IncreaseAbilityId")]
    public Ability IncreaseAbility { get; set; }

    [Required(ErrorMessage = "Ability increase score is required")]
    public int IncreaseAbilityScore { get; set; }

    [Required]
    public int RaceId { get; set; }

    [ForeignKey("RaceId")]
    public Race Race { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; } = [];

}