using GameVault.Application.Platforms.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Platforms.Queries;

public class GetAllPlatformsHandler : IRequestHandler<GetAllPlatformsQuery, List<Platform>>
{
    private readonly AppDbContext _db;
    public GetAllPlatformsHandler(AppDbContext db) => _db = db;

    public async Task<List<Platform>> Handle(GetAllPlatformsQuery request, CancellationToken ct)
    {
        return await _db.Platforms.ToListAsync(ct);
    }
}