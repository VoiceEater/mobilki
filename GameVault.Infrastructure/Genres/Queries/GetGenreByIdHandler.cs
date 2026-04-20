using GameVault.Application.Genres.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Genres.Queries;

public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, Genre?>
{
    private readonly AppDbContext _db;
    public GetGenreByIdHandler(AppDbContext db) => _db = db;

    public async Task<Genre?> Handle(GetGenreByIdQuery request, CancellationToken ct)
    {
        return await _db.Genres.FirstOrDefaultAsync(g => g.Id == request.Id, ct);
    }
}