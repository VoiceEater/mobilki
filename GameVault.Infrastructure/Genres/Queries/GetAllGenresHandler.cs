using GameVault.Application.Genres.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Genres.Queries;

public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, List<Genre>>
{
    private readonly AppDbContext _db;
    public GetAllGenresHandler(AppDbContext db) => _db = db;

    public async Task<List<Genre>> Handle(GetAllGenresQuery request, CancellationToken ct)
    {
        return await _db.Genres.ToListAsync(ct);
    }
}