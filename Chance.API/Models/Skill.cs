using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Skill
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Skill is required")]
    public required string Title { get; set; }

    [JsonIgnore]
    public List<Background> Backgrounds { get; } = [];

    [JsonIgnore]
    public List<Class> Classes { get; } = [];

}