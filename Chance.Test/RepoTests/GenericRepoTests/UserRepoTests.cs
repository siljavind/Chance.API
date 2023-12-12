using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class UserRepoTests : GenericRepoTests<User>
    {
        public UserRepoTests() : base([
            new User { Title = "User", Role = Role.User, PasswordHash = "password" },
            new User { Title = "Admin", Role = Role.Admin, PasswordHash = "password" },
        ])
        { }

        public override User CreateEntity()
        {
            return new User { Title = "UserToo", Role = Role.User, PasswordHash = "password" };
        }
    }
}

