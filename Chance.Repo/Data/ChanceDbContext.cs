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
}

