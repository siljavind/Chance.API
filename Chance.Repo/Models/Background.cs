using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Background
{

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [JsonIgnore]
    public List<Skill> Skills { get; } = [];
}