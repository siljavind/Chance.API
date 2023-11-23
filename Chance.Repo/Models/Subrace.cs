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

    public int IncreaseAbilityId { get; set; }
    [ForeignKey("IncreaseAbilityId")]
    public Ability IncreaseAbility { get; set; }
    public int IncreaseAbilityScore { get; set; }

    public int RaceId { get; set; }
    [ForeignKey("RaceId")]
    public Race Race { get; set; }

    [JsonIgnore]
    public List<Feature> Features { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; set; }

}