using Home_app.Models;
using Microsoft.EntityFrameworkCore;
using Home_app.Models.Calendar;
using Home_app.Models.Health;
using Home_app.Models.Server;

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
        modelBuilder.Entity<HealthRecord>()
            .HasIndex(r => r.Date)
            .IsUnique();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    
    public DbSet<Event> Events { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<Lift> Lifts { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<ServerInfo> ServerInfos { get; set; }
}