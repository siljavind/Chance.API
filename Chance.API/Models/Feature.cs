using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Feature
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public List<Class> Classes { get; } = [];

    [JsonIgnore]
    public List<Race> Races { get; } = [];

    [JsonIgnore]
    public List<Subrace> Subraces { get; } = [];

}