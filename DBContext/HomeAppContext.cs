using Microsoft.EntityFrameworkCore;
using Home_app.Models.Calendar;
using Home_app.Models.Health;

namespace Home_app.DBContext;

public class HomeAppContext : DbContext
{
    public HomeAppContext(DbContextOptions<HomeAppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Tags)
            .WithMany();
    }
    
    public DbSet<Event> Events { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<Lift> Lifts { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
}