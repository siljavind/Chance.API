using Microsoft.EntityFrameworkCore;
using Chance.Repo.Models;

namespace Chance.Repo.Data;

public class ChanceDbContext : DbContext
{
    public ChanceDbContext(DbContextOptions<ChanceDbContext> options) : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }

    public DbSet<Ability> Abilities { get; set; }

    public DbSet<Background> Backgrounds { get; set; }

    public DbSet<Character> Characters { get; set; }

    public DbSet<Class> Classes { get; set; }

    public DbSet<Feature> Features { get; set; }

    public DbSet<Race> Races { get; set; }

    public DbSet<Subrace> Subraces { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            // TODO: Remove this when I have a better way to handle cascading deletes
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        };

        modelBuilder.Entity<Ability>().HasData(
        Enum.GetValues(typeof(AbilityType))
            .Cast<AbilityType>()
            .Select((abilityType) => new Ability { AbilityType = abilityType })
            .ToArray()
            );

        var skillToAbilityMap = new Dictionary<SkillType, AbilityType> {
            { SkillType.Acrobatics, AbilityType.Dexterity },
            { SkillType.AnimalHandling, AbilityType.Wisdom },
            { SkillType.Arcana, AbilityType.Intelligence },
            { SkillType.Athletics, AbilityType.Strength },
            { SkillType.Deception, AbilityType.Charisma },
            { SkillType.History, AbilityType.Intelligence },
            { SkillType.Insight, AbilityType.Wisdom },
            { SkillType.Intimidation, AbilityType.Charisma },
            { SkillType.Investigation, AbilityType.Intelligence },
            { SkillType.Medicine, AbilityType.Wisdom },
            { SkillType.Nature, AbilityType.Intelligence },
            { SkillType.Perception, AbilityType.Wisdom },
            { SkillType.Performance, AbilityType.Charisma },
            { SkillType.Persuasion, AbilityType.Charisma },
            { SkillType.Religion, AbilityType.Intelligence },
            { SkillType.SleightOfHand, AbilityType.Dexterity },
            { SkillType.Stealth, AbilityType.Dexterity },
            { SkillType.Survival, AbilityType.Wisdom }
        };


        modelBuilder.Entity<Skill>().HasData(
        Enum.GetValues(typeof(SkillType))
            .Cast<SkillType>()
            .Select((skillType) => new Skill { SkillType = skillType, AbilityId = skillToAbilityMap[skillType] })
            .ToArray()
            );
    }
}

