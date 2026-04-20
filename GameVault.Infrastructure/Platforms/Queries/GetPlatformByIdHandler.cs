using GameVault.Application.Platforms.Queries;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameVault.Infrastructure.Platforms.Queries;

public class GetPlatformByIdHandler : IRequestHandler<GetPlatformByIdQuery, Platform?>
{
    private readonly AppDbContext _db;
    public GetPlatformByIdHandler(AppDbContext db) => _db = db;

    public async Task<Platform?> Handle(GetPlatformByIdQuery request, CancellationToken ct)
    {
        return await _db.Platforms.FirstOrDefaultAsync(p => p.Id == request.Id, ct);
    }
}