using Chance.Repo.Models;

namespace Chance.Test.RepoTests
{
    public class CharacterRepoTests : GenericRepoTests<Character>
    {
        public CharacterRepoTests() : base([
            new() {Title = "Chance Cheatem", Age = 30, Alignment = Alignment.ChaoticGood, XP = 333, RaceId = 1, SubraceId = 1, ClassId = 1, BackgroundId = 1, UserId = 1},
            new() {Title = "Steve the Human", Age = 1000, Alignment = Alignment.NeutralEvil, XP = 1000, RaceId = 2, SubraceId = 2, ClassId = 2, BackgroundId = 2, UserId = 2},
            new() {Title = "Bob the Elf", Age = 100, Alignment = Alignment.LawfulGood, XP = 100, RaceId = 3, SubraceId = 3, ClassId = 3, BackgroundId = 3, UserId = 3},
            new() {Title = "Joe the Dwarf", Age = 10, Alignment = Alignment.ChaoticNeutral, XP = 10, RaceId = 4, SubraceId = 4, ClassId = 4, BackgroundId = 4, UserId = 4},
        ])
        { }

        public override Character CreateEntity()
        {
            return new Character { Title = "Alessia the Advocate", Age = 25, Alignment = Alignment.LawfulGood, XP = 10000, RaceId = 1, SubraceId = 1, ClassId = 1, BackgroundId = 1, UserId = 1 };
        }
    }
}