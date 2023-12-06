using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Repos;

namespace Chance.Test.RepoTests
{
    public class AbilityRepoTests
    {
        public ChanceDbContext Context { get; set; }
        public DbContextOptions<ChanceDbContext> options;
        private ImmutableRepo<Ability> abilityRepo;

        public AbilityRepoTests()
        {
            options = new DbContextOptionsBuilder<ChanceDbContext>()
            .UseInMemoryDatabase(databaseName: "AbilityTestDb")
            .Options;

            Context = new ChanceDbContext(options);

            if (!Context.Abilities.Any())
                AddAbilities();

            abilityRepo = new ImmutableRepo<Ability>(Context);

        }

        [Fact]
        public async Task GetAll_ShouldReturnAllAbilities()
        {
            //Arrange
            var expected = Context.Abilities.ToList();

            //Act
            var result = await abilityRepo.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Ability>>(result);
            Assert.Equal(expected.Count, result.Count);
        }

        [Fact]
        public async Task GetById_GivenValidId_ShouldReturnCorrectAbility()
        {
            //Arrange
            var expected = Context.Abilities.FirstOrDefault(a => a.Id == 1);

            //Act
            var result = await abilityRepo.GetById(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Ability>(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Title, result.Title);
        }

        private void AddAbilities()
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

