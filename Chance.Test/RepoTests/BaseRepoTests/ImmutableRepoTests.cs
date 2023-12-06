using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Repos;
using Chance.Repo.Interfaces;

public abstract class ImmutableRepoTests<T> where T : class, IImmutable
{
    public ChanceDbContext Context { get; set; }
    public DbContextOptions<ChanceDbContext> options;
    protected ImmutableRepo<T> repo;

    public ImmutableRepoTests()
    {
        options = new DbContextOptionsBuilder<ChanceDbContext>()
        .UseInMemoryDatabase(databaseName: $"{typeof(T).Name}TestDb")
        .Options;

        Context = new ChanceDbContext(options);

        if (!Context.Set<T>().Any())
            AddItems();

        repo = new ImmutableRepo<T>(Context);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllEntities()
    {
        //Arrange
        var expected = Context.Set<T>().ToList();

        //Act
        var result = await repo.GetAll();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<T>>(result);
        Assert.Equal(expected.Count, result.Count);
    }

    [Fact]
    public async Task GetById_GivenValidId_ShouldReturnCorrectEntity()
    {
        //Arrange
        var expected = Context.Set<T>().FirstOrDefault(a => a.Id == 1);

        //Act
        var result = await repo.GetById(1);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<T>(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task GetById_GivenInvalidId_ShouldThrowNotFoundException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => repo.GetById(0));
    }

    public abstract void AddItems();
}