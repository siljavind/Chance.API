using Chance.Repo.Data;
using Chance.Repo.Models;
using Chance.Repo.Repos;
using Chance.Repo.Interfaces;

public abstract class GenericRepoTests<T> where T : class, IGeneric
{
    public ChanceDbContext Context { get; set; }
    public DbContextOptions<ChanceDbContext> options;
    protected GenericRepo<T> repo;

    public GenericRepoTests(List<T> entities)
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

        repo = new GenericRepo<T>(Context);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllEntities()
    {
        //Arrange
        var context = new ChanceDbContext(options);
        var repo = new GenericRepo<T>(context);
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
        var repo = new GenericRepo<T>(context);
        var expected = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == 1);

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
        // Arrange
        var context = new ChanceDbContext(options);
        var repo = new GenericRepo<T>(context);
        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => repo.GetById(0));
    }

    [Fact]
    public async Task Create_GivenValidEntity_ShouldAddEntityToDb()
    {
        //Arrange
        var context = new ChanceDbContext(options);
        var repo = new GenericRepo<T>(context);
        var newEntity = CreateEntity();
        var initialEntities = context.Set<T>().ToList();

        //Act
        var result = await repo.Create(newEntity);

        //Assert

        // Assert that the result is not null and is of the correct type
        Assert.NotNull(result);
        Assert.IsType<T>(result);
        Assert.Equal(newEntity, result); //TODO Does this also check values? Or just reference? 
        Assert.NotEqual(0, result.Id);

        // Assert that the new entity was added to the database and the title is unique
        var allEntities = context.Set<T>().ToList();
        Assert.Contains(result, allEntities);
        Assert.Equal(initialEntities.Count + 1, allEntities.Count);
        Assert.True(initialEntities.All(c => c.Title != newEntity.Title));

        // Assert that the new entity didn't change any of the other entities
        foreach (var inititalEntity in initialEntities)
        {
            var currentEntity = allEntities.Single(c => c.Id == inititalEntity.Id);
            Assert.Equal(inititalEntity, currentEntity);
        }
    }

    //TODO Why is it not throwing an exception when checking in inMemoryDb?
    // [Fact] 
    // public async Task Create_GivenDuplicateTitle_ShouldThrowConflictException()
    // {
    //     // Arrange
    //     var updatedEntity = CreateDuplicate();

    //     // Act & Assert
    //     await Assert.ThrowsAsync<ConflictException>(() => repo.Create(updatedEntity));
    // }

    [Fact]
    public async Task Delete_GivenValidId_ShouldDeleteEntityFromDb()
    {
        // Arrange
        var context = new ChanceDbContext(options);
        var repo = new GenericRepo<T>(context);
        var initialEntities = context.Set<T>().ToList();
        var entityToDelete = context.Set<T>().SingleOrDefault(c => c.Id == 1);

        // Act
        var result = await repo.Delete(entityToDelete.Id);

        // Assert
        Assert.Equal(1, result);
        Assert.Equal(initialEntities.Count - 1, context.Set<T>().Count());
        Assert.DoesNotContain(entityToDelete, context.Set<T>());
    }

    [Fact]
    public async Task Delete_GivenInvalidId_ShouldThrowNotFoundException()
    {
        // Arrange
        var context = new ChanceDbContext(options);
        var repo = new GenericRepo<T>(context);
        var initialEntities = context.Set<T>().ToList();

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => repo.Delete(0));
        Assert.Equal(initialEntities.Count, context.Set<T>().Count());
    }


    // public abstract List<T> AddEntities();
    public abstract T CreateEntity();
    // public abstract T CreateDuplicate();
}