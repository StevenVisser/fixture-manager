using FixtureManager.Persistence.Tables;
using Microsoft.EntityFrameworkCore;

namespace FixtureManager.Persistence;

public class FixtureManagerDbContext : DbContext
{
    public FixtureManagerDbContext(DbContextOptions<FixtureManagerDbContext> options) : base(options) { }

    public DbSet<DbFixture> Fixtures { get; set; }
    public DbSet<DbTeam> Teams { get; set; }
    public DbSet<DbTeamList> TeamLists { get; set; }
    public DbSet<DbUserDetails> UserDetails { get; set; }
    public DbSet<DbSchool> Schools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbTeamList>()
            .HasKey(b => new { b.StudentId, b.TeamId, b.FixtureId });
    }
}
