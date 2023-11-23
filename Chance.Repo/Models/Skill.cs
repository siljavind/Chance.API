using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class Skill
{
    [Key]
    public int Id { get; set; }

    [Required]
    public SkillType SkillType { get; set; }

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