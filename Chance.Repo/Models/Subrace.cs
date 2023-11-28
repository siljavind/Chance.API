using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Subrace
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [ForeignKey("IncreaseAbility")]
    public int IncreaseAbilityId { get; set; }
    public Ability IncreaseAbility { get; set; }

    public int IncreaseAbilityScore { get; set; }

    [ForeignKey("Race")]
    public int RaceId { get; set; }
    public Race Race { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; set; }

}