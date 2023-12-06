using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Models;

[Index(nameof(Title), IsUnique = true)]
public class Subrace
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    public int AbilityId { get; set; }
    [ForeignKey("AbilityId")]
    public Ability? Ability { get; set; }

    public int AbilityScore { get; set; }

    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    public Race? Race { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; set; } = [];

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];

}