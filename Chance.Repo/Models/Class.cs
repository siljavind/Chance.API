using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Class
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Amount of allowed proficiencies required")]
    public int SkillProficiencyCount { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; } = [];

    [JsonIgnore]
    public List<Ability> Abilities { get; } = [];

    [JsonIgnore]
    public List<Skill> Skills { get; } = [];

}