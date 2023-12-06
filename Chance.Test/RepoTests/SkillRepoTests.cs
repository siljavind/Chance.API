
using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Repos;

namespace Chance.Test.RepoTests
{
    public class SkillRepoTests
    {
        public ChanceDbContext Context { get; set; }
        public DbContextOptions<ChanceDbContext> options;
        private ImmutableRepo<Skill> skillRepo;

        public SkillRepoTests()
        {
            options = new DbContextOptionsBuilder<ChanceDbContext>()
            .UseInMemoryDatabase(databaseName: "SkillTestDb")
            .Options;

            Context = new ChanceDbContext(options);
            if (!Context.Skills.Any())
                AddSkills();

            skillRepo = new ImmutableRepo<Skill>(Context);

        }

        [Fact]
        public async Task GetAll_ShouldReturnAllSkillsWithMatchingAbilities()
        {
            //Arrange
            var expected = Context.Skills.ToList();

            //Act
            var result = await skillRepo.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Skill>>(result);
            Assert.Equal(expected.Count, result.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].AbilityId, result[i].AbilityId);
                Assert.Equal(expected[i].Ability, result[i].Ability);
            }
        }

        [Fact]
        public async Task GetById_GivenValidId_ShouldReturnCorrectSkillsWithMatchingAbility()
        {
            //Arrange
            var expected = Context.Skills.FirstOrDefault(a => a.Id == 1);

            //Act
            var result = await skillRepo.GetById(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Skill>(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Title, result.Title);
            Assert.Equal(expected.AbilityId, result.AbilityId);
        }

        private void AddSkills()
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

