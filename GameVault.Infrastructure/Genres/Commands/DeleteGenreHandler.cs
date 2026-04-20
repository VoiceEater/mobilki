using GameVault.Application.Genres.Commands;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Genres.Commands;

public class DeleteGenreHandler : IRequestHandler<DeleteGenreCommand, bool>
{
    private readonly AppDbContext _db;
    public DeleteGenreHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken ct)
    {
        var genre = await _db.Genres.FindAsync(new object[] { request.Id }, ct);
        if (genre == null) return false;
        _db.Genres.Remove(genre);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}