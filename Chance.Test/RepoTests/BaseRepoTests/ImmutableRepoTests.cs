using Chance.Repo.Data;
using Chance.Repo.Repos;
using Chance.Repo.Interfaces;

public abstract class ImmutableRepoTests<T> where T : class, IImmutable
{
    public ChanceDbContext Context { get; set; }
    public DbContextOptions<ChanceDbContext> options;
    protected ImmutableRepo<T> repo;

    public ImmutableRepoTests(List<T> entities)
    {
        options = new DbContextOptionsBuilder<ChanceDbContext>()
        .UseInMemoryDatabase(databaseName: $"{typeof(T).Name}TestDb{Guid.NewGuid()}")
        .Options;

        Context = new ChanceDbContext(options);

        if (!Context.Set<T>().Any())
        {
            Context.Set<T>().AddRange(entities);
            Context.SaveChanges();
        }

        repo = new ImmutableRepo<T>(Context);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllEntities()
    {
        //Arrange
        var context = new ChanceDbContext(options);
        var repo = new ImmutableRepo<T>(context);
        var expected = context.Set<T>().ToList();

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
        var context = new ChanceDbContext(options);
        var repo = new ImmutableRepo<T>(context);
        var expected = context.Set<T>().FirstOrDefault(a => a.Id == 1);

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

}