using GameVault.Application.Genres.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Genres.Commands;

public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, Genre>
{
    private readonly AppDbContext _db;
    public CreateGenreHandler(AppDbContext db) => _db = db;

    public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken ct)
    {
        var genre = new Genre { Name = request.Name };
        _db.Genres.Add(genre);
        await _db.SaveChangesAsync(ct);
        return genre;
    }
}