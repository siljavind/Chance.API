
using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class SkillRepoTests : ImmutableRepoTests<Skill>
    {

        public SkillRepoTests() : base()
        {
            // if (!Context.Skills.Any())
            //     AddItems();

        }

        public override void AddItems()
        {
            Context.Skills.Add(new Skill { Id = 1, Title = 0, AbilityId = 1 });
            Context.Skills.Add(new Skill { Id = 2, Title = (SkillType)1, AbilityId = 2 });
            Context.Skills.Add(new Skill { Id = 3, Title = (SkillType)2, AbilityId = 3 });
            Context.Skills.Add(new Skill { Id = 4, Title = (SkillType)3, AbilityId = 4 });
            Context.Skills.Add(new Skill { Id = 5, Title = (SkillType)4, AbilityId = 5 });
            Context.Skills.Add(new Skill { Id = 6, Title = (SkillType)5, AbilityId = 6 });
            Context.Skills.Add(new Skill { Id = 7, Title = (SkillType)6, AbilityId = 1 });
            Context.Skills.Add(new Skill { Id = 8, Title = (SkillType)7, AbilityId = 2 });
            Context.Skills.Add(new Skill { Id = 9, Title = (SkillType)8, AbilityId = 3 });
            Context.Skills.Add(new Skill { Id = 10, Title = (SkillType)9, AbilityId = 4 });
            Context.SaveChanges();

        }
    }
}