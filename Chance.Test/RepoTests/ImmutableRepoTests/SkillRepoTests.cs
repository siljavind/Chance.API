
using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class SkillRepoTests : ImmutableRepoTests<Skill>
    {

        public SkillRepoTests() : base([
            new() { Title = SkillType.Acrobatics, AbilityId = 1 },
            new() { Title = SkillType.AnimalHandling, AbilityId = 2 },
            new() { Title = SkillType.Arcana, AbilityId = 3 },
            new() { Title = SkillType.Athletics, AbilityId = 4 },
            new() { Title = SkillType.Deception, AbilityId = 5 },
            new() { Title = SkillType.History, AbilityId = 6 },
            new() { Title = SkillType.Insight, AbilityId = 1 },
            new() { Title = SkillType.Intimidation, AbilityId = 2 },
        ])
        { }

    }
}