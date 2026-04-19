using GameVault.Application.Games.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Games.Queries;

public class GetGameByIdHandler : IRequestHandler<GetGameByIdQuery, Game?>
{
    private readonly AppDbContext _db;
    public GetGameByIdHandler(AppDbContext db) => _db = db;

    public async Task<Game?> Handle(GetGameByIdQuery request, CancellationToken ct)
    {
        return await _db.Games
            .Include(g => g.Publisher)
            .Include(g => g.GameGenres).ThenInclude(gg => gg.Genre)
            .Include(g => g.GamePlatforms).ThenInclude(gp => gp.Platform)
            .FirstOrDefaultAsync(g => g.Id == request.Id, ct);
    }
}