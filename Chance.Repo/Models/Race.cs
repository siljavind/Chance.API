using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Race
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Speed is required")]
    public int Speed { get; set; }

    [Required(ErrorMessage = "Size is required")]
    public Size Size { get; set; }

    public int IncreaseAbilityId { get; set; }
    [ForeignKey("IncreaseAbilityId")]
    public Ability IncreaseAbility { get; set; }

    [Required(ErrorMessage = "Ability increase score is required")]
    public int IncreaseAbilityScore { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; } = [];

    [JsonIgnore]
    public List<Subrace> Subraces { get; } = [];
}

public enum Size
{
    Tiny, Small, Medium, Large, Huge, Gargantuan
}