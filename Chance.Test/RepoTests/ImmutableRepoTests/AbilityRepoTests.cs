using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class AbilitiesRepoTests : ImmutableRepoTests<Ability>
    {

        public AbilitiesRepoTests() : base()
        {
            // if (!Context.Abilities.Any())
            //     AddItems();

        }

        public override void AddItems()
        {
            Context.Abilities.Add(new Ability { Id = 1, Title = (AbilityType)0 });
            Context.Abilities.Add(new Ability { Id = 2, Title = (AbilityType)1 });
            Context.Abilities.Add(new Ability { Id = 3, Title = (AbilityType)2 });
            Context.Abilities.Add(new Ability { Id = 4, Title = (AbilityType)3 });
            Context.Abilities.Add(new Ability { Id = 5, Title = (AbilityType)4 });
            Context.Abilities.Add(new Ability { Id = 6, Title = (AbilityType)5 });
            Context.SaveChanges();

        }
    }
}

