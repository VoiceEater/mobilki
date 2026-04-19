using GameVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();
    public DbSet<GameGenre> GameGenres => Set<GameGenre>();
    public DbSet<GamePlatform> GamePlatforms => Set<GamePlatform>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Klucze złożone dla tabel łączących N:M
        modelBuilder.Entity<GameGenre>()
            .HasKey(gg => new { gg.GameId, gg.GenreId });

        modelBuilder.Entity<GamePlatform>()
            .HasKey(gp => new { gp.GameId, gp.PlatformId });

        // Precyzja dla decimal
        modelBuilder.Entity<Game>()
            .Property(g => g.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.UnitPrice)
            .HasPrecision(18, 2);

        // Seed danych
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "Customer" }
        );

        modelBuilder.Entity<Publisher>().HasData(
            new Publisher { Id = 1, Name = "CD Projekt Red", Country = "Poland" },
            new Publisher { Id = 2, Name = "Valve", Country = "USA" },
            new Publisher { Id = 3, Name = "FromSoftware", Country = "Japan" }
        );

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "RPG" },
            new Genre { Id = 2, Name = "FPS" },
            new Genre { Id = 3, Name = "Strategy" },
            new Genre { Id = 4, Name = "Action" },
            new Genre { Id = 5, Name = "Adventure" }
        );

        modelBuilder.Entity<Platform>().HasData(
            new Platform { Id = 1, Name = "PC" },
            new Platform { Id = 2, Name = "PlayStation 5" },
            new Platform { Id = 3, Name = "Xbox Series X" },
            new Platform { Id = 4, Name = "Nintendo Switch" }
        );

        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Title = "Cyberpunk 2077", Description = "Open world RPG", Price = 199.99m, ReleaseDate = new DateTime(2020, 12, 10), ImageUrl = "cyberpunk.jpg", PublisherId = 1 },
            new Game { Id = 2, Title = "The Witcher 3", Description = "Fantasy RPG", Price = 129.99m, ReleaseDate = new DateTime(2015, 5, 19), ImageUrl = "witcher3.jpg", PublisherId = 1 },
            new Game { Id = 3, Title = "Counter-Strike 2", Description = "Tactical FPS", Price = 0m, ReleaseDate = new DateTime(2023, 9, 27), ImageUrl = "cs2.jpg", PublisherId = 2 },
            new Game { Id = 4, Title = "Elden Ring", Description = "Action RPG", Price = 249.99m, ReleaseDate = new DateTime(2022, 2, 25), ImageUrl = "eldenring.jpg", PublisherId = 3 }
        );

        modelBuilder.Entity<GameGenre>().HasData(
            new GameGenre { GameId = 1, GenreId = 1 },
            new GameGenre { GameId = 1, GenreId = 4 },
            new GameGenre { GameId = 2, GenreId = 1 },
            new GameGenre { GameId = 2, GenreId = 5 },
            new GameGenre { GameId = 3, GenreId = 2 },
            new GameGenre { GameId = 4, GenreId = 1 },
            new GameGenre { GameId = 4, GenreId = 4 }
        );

        modelBuilder.Entity<GamePlatform>().HasData(
            new GamePlatform { GameId = 1, PlatformId = 1 },
            new GamePlatform { GameId = 1, PlatformId = 2 },
            new GamePlatform { GameId = 1, PlatformId = 3 },
            new GamePlatform { GameId = 2, PlatformId = 1 },
            new GamePlatform { GameId = 2, PlatformId = 2 },
            new GamePlatform { GameId = 2, PlatformId = 4 },
            new GamePlatform { GameId = 3, PlatformId = 1 },
            new GamePlatform { GameId = 4, PlatformId = 1 },
            new GamePlatform { GameId = 4, PlatformId = 2 },
            new GamePlatform { GameId = 4, PlatformId = 3 }
        );
    }
}