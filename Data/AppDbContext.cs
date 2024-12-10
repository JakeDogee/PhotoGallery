using Microsoft.EntityFrameworkCore;
using PhotoGalery.Entities;

namespace PhotoGalery.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Photo> Photos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            UserName = "admin",
            Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
            Role = "Admin"
        });
    }
}