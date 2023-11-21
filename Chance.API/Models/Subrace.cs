using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Subrace
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }

    public Ability IncreaseAbility { get; set; }
    public int IncreaseScore { get; set; }

    public Race Race { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; } = [];

}