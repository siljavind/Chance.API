using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Chance.Repo.Interfaces;

namespace Chance.Repo.Models;

public class Skill
{
    [Key]
    public SkillType Id { get; set; }

    [Required]
    [ForeignKey("Ability")]
    public AbilityType AbilityId { get; set; }
    public Ability Ability { get; set; }

    [JsonIgnore]
    public List<Background> Backgrounds { get; set; }

    [JsonIgnore]
    public List<Class> Classes { get; set; }
}

public enum SkillType
{
    Acrobatics = 1,
    AnimalHandling,
    Arcana,
    Athletics,
    Deception,
    History,
    Insight,
    Intimidation,
    Investigation,
    Medicine,
    Nature,
    Perception,
    Performance,
    Persuasion,
    Religion,
    SleightOfHand,
    Stealth,
    Survival
}