using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Interfaces;

namespace Chance.Repo.Models;

[Index(nameof(Title), IsUnique = true)]
public class Class : IGeneric
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Amount of allowed proficiencies required")]
    public int SkillProficiencyCount { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; set; } = [];

    [JsonIgnore]
    public List<Ability> Abilities { get; set; } = [];

    [JsonIgnore]
    public List<Skill> Skills { get; set; } = [];

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];

}