using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Race
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }
    public int Speed { get; set; }
    public Size Size { get; set; }
    public Ability IncreaseAbility { get; set; }
    public int IncreaseScore { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; } = [];
}

public enum Size
{
    Tiny, Small, Medium, Large, Huge, Gargantuan
}