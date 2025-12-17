using Microsoft.EntityFrameworkCore;
using Portfolio.Model;

namespace Portfolio.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Profile> Profiles => Set<Profile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id);

            // Auto-increment identity (PostgreSQL + InMemory compatible)
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();
        });
    }
}
