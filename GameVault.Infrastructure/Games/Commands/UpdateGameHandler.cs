using GameVault.Application.Games.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Games.Commands;

public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, Game?>
{
    private readonly AppDbContext _db;
    public UpdateGameHandler(AppDbContext db) => _db = db;

    public async Task<Game?> Handle(UpdateGameCommand request, CancellationToken ct)
    {
        var game = await _db.Games
            .Include(g => g.GameGenres)
            .Include(g => g.GamePlatforms)
            .FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (game == null) return null;

        game.Title = request.Title;
        game.Description = request.Description;
        game.Price = request.Price;
        game.ReleaseDate = request.ReleaseDate;
        game.ImageUrl = request.ImageUrl;
        game.PublisherId = request.PublisherId;

        game.GameGenres.Clear();
        game.GameGenres = request.GenreIds.Select(id => new GameGenre { GameId = game.Id, GenreId = id }).ToList();

        game.GamePlatforms.Clear();
        game.GamePlatforms = request.PlatformIds.Select(id => new GamePlatform { GameId = game.Id, PlatformId = id }).ToList();

        await _db.SaveChangesAsync(ct);
        return game;
    }
}