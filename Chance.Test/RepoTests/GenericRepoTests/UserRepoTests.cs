using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class UserRepoTests : GenericRepoTests<User>
    {
        public UserRepoTests() : base([
            new User { Title = "User", Role = Role.User },
            new User { Title = "Admin", Role = Role.Admin },
        ])
        { }

        public override User CreateEntity()
        {
            return new User { Title = "UserToo", Role = Role.User };
        }
    }
}

