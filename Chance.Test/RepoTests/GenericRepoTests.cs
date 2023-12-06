using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Chance.Test.RepoTests
{
    public class GenericRepoTests
    {
        [Fact]
        public async Task GetAll_ReturnsListOfEntities()
        {
            var data = new List<MyEntity>
            {
                new MyEntity { Id = 1, Title = "Test 1" },
                new MyEntity { Id = 2, Title = "Test 2" },
                new MyEntity { Id = 3, Title = "Test 3" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<MyEntity>>();
            mockSet.As<IQueryable<MyEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MyEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MyEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MyEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ChanceDbContext>();
            mockContext.Setup(c => c.Set<MyEntity>()).Returns(mockSet.Object);

            var repo = new GenericRepo<MyEntity>(mockContext.Object);

            var result = await repo.GetAll();

            Assert.Equal(data.ToList(), result);
        }
    }
}