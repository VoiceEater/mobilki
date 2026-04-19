using GameVault.Application.Games.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Games.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, Game>
{
    private readonly AppDbContext _db;
    public CreateGameHandler(AppDbContext db) => _db = db;

    public async Task<Game> Handle(CreateGameCommand request, CancellationToken ct)
    {
        var game = new Game
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            ReleaseDate = request.ReleaseDate,
            ImageUrl = request.ImageUrl,
            PublisherId = request.PublisherId
        };

        game.GameGenres = request.GenreIds.Select(id => new GameGenre { GenreId = id }).ToList();
        game.GamePlatforms = request.PlatformIds.Select(id => new GamePlatform { PlatformId = id }).ToList();

        _db.Games.Add(game);
        await _db.SaveChangesAsync(ct);
        return game;
    }
}