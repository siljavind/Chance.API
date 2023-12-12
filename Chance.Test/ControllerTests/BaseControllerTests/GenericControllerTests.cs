using Chance.Repo.Models;
using Chance.Controller.Controllers;
using Moq;
using Chance.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Chance.Test.ControllerTests
{
    public abstract class GenericControllerTests<T> : ControllerBase where T : class, IGeneric
    {
        private readonly Mock<IGenericRepo<T>> _mockRepo = new();
        private readonly List<T> _entities;

        public GenericControllerTests(List<T> entities)
        {
            _entities = entities;
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(_entities);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllEntities_GivenEntitiesExist()
        {
            //Arrange
            var expected = _entities;
            var controller = CreateController(_mockRepo.Object);

            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(expected);

            //Act
            var result = await controller.Get();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expected, okResult.Value);
        }
        [Fact]
        public async Task GetAll_ShouldReturnNotFound_GivenNoEntitiesExist()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(() => throw new NotFoundException());

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Get();

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetById_GivenValidId_ShouldReturnCorrectEntity()
        {
            //Arrange
            var expected = _entities.FirstOrDefault(e => e.Id == 1);
            _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(expected);

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Get(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public async Task GetById_GivenInvalidId_ShouldReturnNotFound()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(() => throw new NotFoundException());

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Get(1);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetByTitle_GivenValidTitle_ShouldReturnCorrectEntity()
        {
            //Arrange
            var expected = _entities.FirstOrDefault(e => e.Title == _entities[0].Title);
            _mockRepo.Setup(repo => repo.GetByTitle("Charlatan")).ReturnsAsync(expected);

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Get("Charlatan");

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public async Task GetByTitle_GivenInvalidTitle_ShouldReturnNotFound()
        {
            //Arrange
            _mockRepo.Setup(repo => repo.GetByTitle("Not here")).ReturnsAsync(() => throw new NotFoundException());

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Get("Not here");

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Create_GivenValidEntity_ShouldAddEntityToDb()
        {
            //Arrange
            var newEntity = CreateEntity();
            _mockRepo.Setup(repo => repo.Create(newEntity)).ReturnsAsync(newEntity);

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Post(newEntity);

            //Assert
            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(newEntity, okResult.Value);
        }

        [Fact]
        public async Task Create_GivenDuplicateEntity_ShouldReturnConflict()
        {
            //Arrange
            var duplicateEntity = CreateDuplicateEntity();
            _mockRepo.Setup(repo => repo.Create(duplicateEntity)).ReturnsAsync(() => throw new ConflictException());

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Post(duplicateEntity);

            //Assert
            var conflictResult = Assert.IsType<ConflictResult>(result.Result);
        }

        [Fact]
        public async Task Update_GivenValidEntity_ShouldUpdateEntityInDb()
        {
            //Arrange
            var updatedEntity = CreateUpdatedEntity();
            _mockRepo.Setup(repo => repo.Update(updatedEntity)).ReturnsAsync(updatedEntity);

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Put(1, updatedEntity);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(updatedEntity, okResult.Value);
        }

        public async Task Update_GivenInvalidEntityId_ShouldReturnBadRequest()
        {
            //Arrange
            var updatedEntity = CreateUpdatedEntity();
            _mockRepo.Setup(repo => repo.Update(updatedEntity)).ReturnsAsync(() => throw new BadRequestException());

            var controller = CreateController(_mockRepo.Object);

            //Act
            var result = await controller.Put(2, updatedEntity);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        public abstract GenericController<T> CreateController(IGenericRepo<T> repo);
        public abstract T CreateEntity();
        public abstract T CreateDuplicateEntity();

        public abstract T CreateUpdatedEntity();

    }
}

