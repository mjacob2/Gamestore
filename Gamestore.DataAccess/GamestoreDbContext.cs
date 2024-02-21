using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static Gamestore.DataAccess.Entities.Order;

namespace Gamestore.DataAccess;

public class GamestoreDbContext : DbContext
{
    public GamestoreDbContext(DbContextOptions<GamestoreDbContext> options)
            : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Publisher> Publisher { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Shipper> Shippers { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.Name)
            .IsUnique();

        modelBuilder.Entity<Platform>()
            .HasIndex(e => e.Type)
            .IsUnique();

        modelBuilder.Entity<Publisher>()
            .HasIndex(e => e.CompanyName)
            .IsUnique();

        modelBuilder.Entity<Genre>()
            .HasMany(g => g.SubGenres)
            .WithOne(g => g.ParentGenre)
            .HasForeignKey(g => g.ParentGenreId);

        modelBuilder.Entity<Platform>()
            .Property(e => e.Type)
            .HasConversion(
            v => v.ToString(),
            v => (PlatformType)Enum.Parse(typeof(PlatformType), v));

        modelBuilder.Entity<Order>()
            .Property(e => e.Status)
            .HasConversion(
    v => v.ToString(),
    v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v));
    }
}