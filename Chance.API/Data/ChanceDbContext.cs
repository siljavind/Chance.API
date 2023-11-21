using Microsoft.EntityFrameworkCore;
using Chance.API.Models;

namespace Chance.API.Data;

public class ChanceDbContext : DbContext
{
    public ChanceDbContext(DbContextOptions<ChanceDbContext> options) : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }


    // Define DbSet properties for entities
    // Example:
    // public DbSet<User> Users { get; set; }
}

