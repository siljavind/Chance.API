using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class SubraceRepoTests : GenericRepoTests<Subrace>
    {
        public SubraceRepoTests() : base([
            new Subrace { Title = "Lightfoot Halfling", AbilityId = 1, AbilityScore = 2 },
            new Subrace { Title = "Stout Halfling", AbilityId = 2, AbilityScore = 1 },
            new Subrace { Title = "High Elf", AbilityId = 3, AbilityScore = 3 },
            new Subrace { Title = "Wood Elf", AbilityId = 4, AbilityScore = 2 },
        ])
        { }

        public override Subrace CreateEntity()
        {
            return new Subrace { Title = "Dark Elf", AbilityId = 5, AbilityScore = 2 };
        }
    }
}

