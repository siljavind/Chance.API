using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class BackgroundRepoTests : GenericRepoTests<Background>
    {

        public BackgroundRepoTests() : base([
            new() { Title = "Charlatan" },
            new() { Title = "Criminal" },
            new() { Title = "Entertainer" },
            new() { Title = "Folk Hero" },
            new() { Title = "Guild Artisan" },
        ])
        { }

        public override Background CreateEntity()
        {
            return new Background { Title = "Acolyte" };
        }

        // public override Background CreateDuplicate()
        // {
        //     return new Background { Title = "Charlatan" };
        // }
    }
}



// using Chance.Repo.Data;
// using Chance.Repo.Models;
// using Chance.Repo.Repos;

// namespace Chance.Test.RepoTests
// {
//     public class BackgroundRepoTests
//     {
//         public ChanceDbContext Context { get; set; }
//         public DbContextOptions<ChanceDbContext> options;
//         private GenericRepo<Background> backgroundRepo;

//         public BackgroundRepoTests()
//         {
//             options = new DbContextOptionsBuilder<ChanceDbContext>()
//             .UseInMemoryDatabase(databaseName: "BackgroundTestDb")
//             .Options;

//             Context = new ChanceDbContext(options);

//             if (!Context.Backgrounds.Any())
//                 AddBackgrounds();

//             backgroundRepo = new GenericRepo<Background>(Context);
//         }

//         [Fact]
//         public async Task GetAll_ShouldReturnAllBackgrounds()
//         {
//             //Arrange
//             var expected = Context.Backgrounds.ToList();

//             //Act
//             var result = await backgroundRepo.GetAll();

//             //Assert
//             Assert.NotNull(result);
//             Assert.IsType<List<Background>>(result);
//             Assert.Equal(expected.Count, result.Count);
//         }

//         [Fact]
//         public async Task GetById_GivenValidId_ShouldReturnCorrectBackground()
//         {
//             //Arrange
//             var expected = Context.Backgrounds.FirstOrDefault(a => a.Id == 1);

//             //Act
//             var result = await backgroundRepo.GetById(1);

//             //Assert
//             Assert.NotNull(result);
//             Assert.IsType<Background>(result);
//             Assert.Equal(expected.Id, result.Id);
//             Assert.Equal(expected.Title, result.Title);
//             Assert.Equal(expected.SkillProficiencyCount, result.SkillProficiencyCount);
//         }


//         [Fact]
//         public async Task Create_GivenValidBackground_ShouldAddBackgroundToDb()
//         {
//             //Arrange
//             var newBackground = new Background { Title = "Monk", SkillProficiencyCount = 2 };
//             var initialBackgrounds = Context.Backgrounds.ToList();

//             //Act
//             var result = await backgroundRepo.Create(newBackground);

//             //Assert

//             // Assert that the result is not null, is of type Background, and has the correct properties
//             Assert.NotNull(result);
//             Assert.IsType<Background>(result);
//             Assert.Equal(newBackground.Title, result.Title);
//             Assert.Equal(newBackground.SkillProficiencyCount, result.SkillProficiencyCount);
//             Assert.NotEqual(0, result.Id);

//             // Assert that the new background was added to the database and the title is unique
//             var allBackgrounds = Context.Backgrounds.ToList();
//             Assert.Contains(result, allBackgrounds);
//             Assert.Equal(initialBackgrounds.Count + 1, allBackgrounds.Count);
//             Assert.True(allBackgrounds.All(c => c.Title != newBackground.Title));

//             // Assert that the new background didn't change any of the other backgroundes
//             foreach (var inititalBackground in initialBackgrounds)
//             {
//                 var currentBackground = allBackgrounds.Single(c => c.Id == inititalBackground.Id);
//                 Assert.Equal(inititalBackground.Title, currentBackground.Title);
//                 Assert.Equal(inititalBackground.SkillProficiencyCount, currentBackground.SkillProficiencyCount);
//             }
//         }
//         [Fact]
//         public async Task Create_GivenDuplicateTitle_ShouldThrowConflictException()
//         {
//             // Arrange
//             var updatedBackground = new Background { Title = "Rogue", SkillProficiencyCount = 2 };

//             // Act & Assert
//             await Assert.ThrowsAsync<ConflictException>(() => backgroundRepo.Create(updatedBackground));
//         }

//         [Fact]
//         public async Task Update_GivenValidBackground_ShouldUpdateBackgroundInDb()
//         {
//             // Arrange
//             var initialBackgrounds = Context.Backgrounds.ToList();
//             var initialBackground = Context.Backgrounds.Single(c => c.Id == 1);
//             var updatedBackground = new Background { Id = 1, Title = "Updated Background", SkillProficiencyCount = 2 };

//             // Act 
//             var result = await backgroundRepo.Update(updatedBackground);

//             // Assert
//             Assert.NotNull(result);
//             Assert.IsType<Background>(result);
//             Assert.Equal(updatedBackground.Id, result.Id);
//             Assert.Equal(updatedBackground.Title, result.Title);
//             Assert.Equal(updatedBackground.SkillProficiencyCount, result.SkillProficiencyCount);
//             Assert.Equal(initialBackgrounds.Count, Context.Backgrounds.Count());
//         }

//         [Fact]
//         public async Task Update_GivenInvalidBackgroundId_ShouldThrowNotFoundException()
//         {
//             // Arrange
//             var updatedBackground = new Background { Id = 100, Title = "Updated Background", SkillProficiencyCount = 2 };

//             // Act & Assert
//             await Assert.ThrowsAsync<NotFoundException>(() => backgroundRepo.Update(updatedBackground));
//         }

//         [Fact]
//         public async Task Update_GivenNullValues_ShouldOnlyUpdateNonNull()
//         {
//             // Arrange
//             var initialBackground = Context.Backgrounds.Single(c => c.Id == 1);
//             var updatedBackground = new Background { Id = 1, Title = "New Title" };

//             // Detach the initialBackground from the DbContext so I can call Update() without getting an EF error
//             Context.Entry(initialBackground).State = EntityState.Detached;

//             // Act
//             var result = await backgroundRepo.Update(updatedBackground);

//             // Assert
//             Assert.NotNull(result);
//             Assert.IsType<Background>(result);
//             Assert.Equal(updatedBackground.Id, result.Id);
//             Assert.Equal(updatedBackground.Title, result.Title);
//             Assert.Equal(initialBackground.SkillProficiencyCount, result.SkillProficiencyCount);
//         }

//         [Fact]
//         public async Task Update_GivenDuplicateTitle_ShouldThrowConflictException()
//         {
//             // Arrange
//             var updatedBackground = new Background { Id = 1, Title = "Fighter", SkillProficiencyCount = 3 };

//             var result = backgroundRepo.Update(updatedBackground);

//             // Act & Assert
//             await Assert.ThrowsAsync<ConflictException>(() => backgroundRepo.Update(updatedBackground));
//             Assert.NotEqual(updatedBackground.Title, Context.Backgrounds.Single(c => c.Id == 1).Title);
//         }

//         [Fact]
//         public async Task Delete_GivenValidId_ShouldDeleteBackgroundFromDb()
//         {
//             // Arrange
//             var initialBackgrounds = Context.Backgrounds.ToList();
//             var initialBackground = Context.Backgrounds.Single(c => c.Id == 1);

//             // Act
//             var result = await backgroundRepo.Delete(1);

//             // Assert
//             Assert.Equal(1, result);
//             Assert.Equal(initialBackgrounds.Count - 1, Context.Backgrounds.Count());
//             Assert.DoesNotContain(initialBackground, Context.Backgrounds);
//         }

//         [Fact]
//         public async Task Delete_GivenInvalidId_ShouldThrowNotFoundException()
//         {
//             // Arrange
//             var initialBackgrounds = Context.Backgrounds.ToList();

//             // Act & Assert
//             await Assert.ThrowsAsync<NotFoundException>(() => backgroundRepo.Delete(100));
//             Assert.Equal(initialBackgrounds.Count, Context.Backgrounds.Count());
//         }

//         private void AddBackgrounds()
//         {
//             Context.Backgrounds.Add(new Background { Id = 1, Title = "Charlatan" });
//             Context.Backgrounds.Add(new Background { Id = 2, Title = "Criminal" });
//             Context.Backgrounds.Add(new Background { Id = 3, Title = "Entertainer" });
//             Context.Backgrounds.Add(new Background { Id = 4, Title = "Folk Hero" });
//             Context.Backgrounds.Add(new Background { Id = 5, Title = "Guild Artisan" });
//             Context.SaveChanges();
//         }
//     }
// }

