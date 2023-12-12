using Chance.Repo.Models;
using Chance.Controller.Controllers;
using Chance.Repo.Interfaces;

namespace Chance.Test.ControllerTests
{
    public class ClassControllerTests : GenericControllerTests<Class>
    {
        public ClassControllerTests() : base([
            new() { Id = 1, Title = "Bard", SkillProficiencyCount = 3 },
            new() { Id = 2, Title = "Rogue", SkillProficiencyCount = 4 },
            new() { Id = 3, Title = "Fighter", SkillProficiencyCount = 2 },
            new() { Id = 4, Title = "Wizard", SkillProficiencyCount = 2 },
        ])
        { }

        public override GenericController<Class> CreateController(IGenericRepo<Class> repo) =>
            new ClassesController(repo);

        public override Class CreateEntity() =>
            new() { Id = 5, Title = "Clecric", SkillProficiencyCount = 2 };

        public override Class CreateDuplicateEntity() =>
            new() { Id = 1, Title = "Bard", SkillProficiencyCount = 3 };

        public override Class CreateUpdatedEntity() =>
            new() { Id = 1, Title = "Bard2", SkillProficiencyCount = 3 };
    }
}
