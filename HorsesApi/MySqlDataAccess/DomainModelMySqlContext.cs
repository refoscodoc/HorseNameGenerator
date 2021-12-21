using HorsesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HorsesApi.MySqlDataAccess;

// >dotnet ef migration add testMigration
public class DomainModelMySqlContext : DbContext
{
    public DomainModelMySqlContext(DbContextOptions<DomainModelMySqlContext> options) : base(options)
    { }

    public DbSet<EngWord> EnglishDictionary { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<HorseName>().HasKey(m => m.HorseId);
        //
        // // shadow properties
        // builder.Entity<HorseName>().Property<DateTime>("UpdatedTimestamp");

        // builder.Entity<EngWord>();
        builder.Entity<EngWord>().ToTable("entries");

        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
            
        UpdateUpdatedProperty<HorseName>();
            
        return base.SaveChanges();
    }

    private void UpdateUpdatedProperty<T>() where T : class
    {
        var modifiedSourceInfo =
            ChangeTracker.Entries<T>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in modifiedSourceInfo)
        {
            entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
        }
    }
}