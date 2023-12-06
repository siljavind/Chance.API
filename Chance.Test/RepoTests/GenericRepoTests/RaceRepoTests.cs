using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class RaceRepoTests : GenericRepoTests<Race>
    {
        public RaceRepoTests() : base([
            new Race { Title = "Race 1", Speed = 30, Size = Size.Small, AbilityId = 1, IncreaseAbilityScore = 2 },
            new Race { Title = "Race 2", Speed = 20, Size = Size.Tiny, AbilityId = 2, IncreaseAbilityScore = 1 },
            new Race { Title = "Race 3", Speed = 25, Size = Size.Large, AbilityId = 3, IncreaseAbilityScore = 3 },
            new Race { Title = "Race 4", Speed = 30, Size = Size.Gargantuan, AbilityId = 4, IncreaseAbilityScore = 2 },
        ])
        { }

        public override Race CreateEntity()
        {
            return new Race { Title = "Race 5", Speed = 35, Size = Size.Huge, AbilityId = 5, IncreaseAbilityScore = 2 };
        }
    }
}

