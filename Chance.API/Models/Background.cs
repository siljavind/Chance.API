using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class Background
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }

    [JsonIgnore]
    public List<Skill> Skills { get; } = [];

}