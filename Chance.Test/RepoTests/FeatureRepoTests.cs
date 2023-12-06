using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class FeatureRepoTests : GenericRepoTests<Feature>
    {
        public FeatureRepoTests() : base([
            new() { Title = "Feature 1", Description = "Description" },
            new() { Title = "Feature 2", Description = "Description" },
            new() { Title = "Feature 3", Description = "Description" },
            new() { Title = "Feature 4"},
            new() { Title = "Feature 5"},
        ])
        { }

        public override Feature CreateEntity()
        {
            return new Feature { Title = "Feature 6", Description = "Description" };
        }
    }
}

