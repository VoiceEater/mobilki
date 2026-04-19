using GameVault.Application.Games.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Games.Commands;

public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteGameHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteGameCommand request, CancellationToken ct)
    {
        var game = await _db.Games.FindAsync(new object[] { request.Id }, ct);
        if (game == null) return false;

        _db.Games.Remove(game);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}