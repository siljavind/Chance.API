using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Skill
{
    [Key]
    public SkillType SkillType { get; set; }

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
    Acrobatics,
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