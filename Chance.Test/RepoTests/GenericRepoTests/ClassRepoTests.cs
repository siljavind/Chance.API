using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class ClassRepoTests : GenericRepoTests<Class>
    {
        public ClassRepoTests() : base([
            new() { Title = "Bard", SkillProficiencyCount = 3 },
            new() { Title = "Rogue", SkillProficiencyCount = 4 },
            new() { Title = "Fighter", SkillProficiencyCount = 2 },
            new() { Title = "Wizard", SkillProficiencyCount = 2 },
            new() { Title = "Cleric", SkillProficiencyCount = 2 },
            new() { Title = "Barbarian", SkillProficiencyCount = 2 },
            new() { Title = "Druid", SkillProficiencyCount = 2 },
        ])
        { }

        public override Class CreateEntity()
        {
            return new Class { Title = "Monk", SkillProficiencyCount = 2 };
        }
    }
}

