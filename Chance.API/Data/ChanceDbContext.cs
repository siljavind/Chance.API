using Microsoft.EntityFrameworkCore;
using Chance.API.Models;

namespace Chance.API.Data;

public class ChanceDbContext : DbContext
{
    public ChanceDbContext(DbContextOptions<ChanceDbContext> options) : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }

    public DbSet<Ability> Ability { get; set; } = default!;

    public DbSet<Background> Background { get; set; } = default!;

    public DbSet<Character> Character { get; set; } = default!;

    public DbSet<Class> Class { get; set; } = default!;

    public DbSet<Feature> Feature { get; set; } = default!;

    public DbSet<Race> Race { get; set; } = default!;

    public DbSet<Subrace> Subrace { get; set; } = default!;

    public DbSet<User> User { get; set; } = default!;


    // Define DbSet properties for entities
    // Example:
    // public DbSet<User> Users { get; set; }
}

