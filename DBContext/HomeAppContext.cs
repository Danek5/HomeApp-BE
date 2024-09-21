using Microsoft.EntityFrameworkCore;
using Home_app.Models.Calendar;

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
}