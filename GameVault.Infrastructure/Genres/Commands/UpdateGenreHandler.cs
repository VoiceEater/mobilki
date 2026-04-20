using GameVault.Application.Genres.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Genres.Commands;

public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, Genre?>
{
    private readonly AppDbContext _db;
    public UpdateGenreHandler(AppDbContext db) => _db = db;

    public async Task<Genre?> Handle(UpdateGenreCommand request, CancellationToken ct)
    {
        var genre = await _db.Genres.FindAsync(new object[] { request.Id }, ct);
        if (genre == null) return null;
        genre.Name = request.Name;
        await _db.SaveChangesAsync(ct);
        return genre;
    }
}