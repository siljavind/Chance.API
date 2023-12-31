using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Models;

[Index(nameof(Title), IsUnique = true)]
public class Race : IGeneric
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Speed is required")]
    public int Speed { get; set; }

    [Required(ErrorMessage = "Size is required")]
    public Size Size { get; set; }

    public int AbilityId { get; set; }
    [ForeignKey("AbilityId")]
    public Ability? Ability { get; set; }

    [Required(ErrorMessage = "Ability increase score is required")]
    public int IncreaseAbilityScore { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; set; } = [];

    [JsonIgnore]
    public List<Subrace> Subraces { get; set; } = [];

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];
}

public enum Size
{
    Tiny, Small, Medium, Large, Huge, Gargantuan
}