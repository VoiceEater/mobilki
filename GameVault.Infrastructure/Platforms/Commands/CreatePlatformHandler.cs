using GameVault.Application.Platforms.Commands;
using GameVault.Domain.Entities;
using GameVault.Infrastructure.Data;
using MediatR;

namespace GameVault.Infrastructure.Platforms.Commands;

public class CreatePlatformHandler : IRequestHandler<CreatePlatformCommand, Platform>
{
    private readonly AppDbContext _db;
    public CreatePlatformHandler(AppDbContext db) => _db = db;

    public async Task<Platform> Handle(CreatePlatformCommand request, CancellationToken ct)
    {
        var platform = new Platform { Name = request.Name };
        _db.Platforms.Add(platform);
        await _db.SaveChangesAsync(ct);
        return platform;
    }
}