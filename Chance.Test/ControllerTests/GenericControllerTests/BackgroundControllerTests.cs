using Chance.Repo.Models;
using Chance.Controller.Controllers;
using Chance.Repo.Interfaces;

namespace Chance.Test.ControllerTests
{
    public class BackgroundControllerTests : GenericControllerTests<Background>
    {
        public BackgroundControllerTests() : base([
                new() { Id = 1, Title = "Charlatan" },
                new() { Id = 2, Title = "Criminal" },
                new() { Id = 3, Title = "Entertainer" },
                new() { Id = 4, Title = "Folk Hero" },
            ])
        { }

        public override GenericController<Background> CreateController(IGenericRepo<Background> repo) =>
            new BackgroundsController(repo);

        public override Background CreateEntity() =>
            new() { Id = 5, Title = "Acolyte" };

        public override Background CreateDuplicateEntity() =>
            new() { Id = 1, Title = "Charlatan" };

        public override Background CreateUpdatedEntity() =>
            new() { Id = 1, Title = "Charlatan2" };
    }
}
