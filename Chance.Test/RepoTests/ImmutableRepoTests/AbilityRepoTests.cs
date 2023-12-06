using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class AbilitiesRepoTests : ImmutableRepoTests<Ability>
    {

        public AbilitiesRepoTests() : base([
            new() { Title = AbilityType.Strength },
            new() { Title = AbilityType.Dexterity },
            new() { Title = AbilityType.Constitution },
            new() { Title = AbilityType.Intelligence },
            new() { Title = AbilityType.Wisdom },
            new() { Title = AbilityType.Charisma },
        ])
        { }
    }
}

